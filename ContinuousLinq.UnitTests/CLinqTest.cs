using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using ContinuousLinq;
using ContinuousLinq.Aggregates;
using NUnit.Framework;

namespace ContinuousLinq.UnitTests
{
    [TestFixture]
    public class CLinqTest
    {       
        private ContinuousCollection<Person> _target;
        private ContinuousCollection<Person> _source;

        [SetUp]
        public void Initialize()
        {
            _target = null;
            _source = new ContinuousCollection<Person>();

            AddItemsToSource();            
        }

        [TearDown]
        public void Cleanup()
        {
            
        }

        [Test]
        public void FilteringViewAdapter_OnAgeGreaterThan30_ReturnsCollectionWithPersonsOlderThan30()
        {           
            _target = from item in _source
                      where item.Age > 30
                      select item;

            Assert.AreEqual(2, _target.Count);
            Assert.AreEqual("Jordan", _target[0].Name);
            Assert.AreEqual("Erb", _target[1].Name);

            _source.Add(new Person("John", 12));

            Assert.AreEqual(2, _target.Count);

            _source.Add(new Person("Tim", 34));

            Assert.AreEqual(3, _target.Count);
            Assert.AreEqual("Tim", _target[2].Name);
        }

        [Test]
        public void SortingViewAdapater_ByName_ReturnsCollectionOrderedAscendingByName()
        {
            _target = from item in _source
                      orderby item.Name
                      select item;

            Assert.AreEqual(6, _target.Count);
            Assert.AreEqual("Erb", _target[1].Name);
            Assert.AreEqual("Steve", _target[5].Name);

            _source.Add(new Person("Dan", 100));

            Assert.AreEqual("Dan", _target[0].Name);
            Assert.AreEqual("David", _target[1].Name);            
        }

        [Test]
        public void GroupingViewAdapter_ByAge_ReturnsPersonsGroupedByAge()
        {
            var personGroups = from item in _source
                               group item by item.Age into g
                               select new { Age = g.Key, Persons = g };

            Assert.AreEqual(4, personGroups.Count);

            Assert.AreEqual(27, personGroups[0].Age);
            Assert.AreEqual(1, personGroups[0].Persons.Count);
            Assert.AreEqual("David", personGroups[0].Persons[0].Name);

            Assert.AreEqual(30, personGroups[2].Age);
            Assert.AreEqual(2, personGroups[2].Persons.Count);
            Assert.AreEqual("Steve", personGroups[2].Persons[0].Name);
            Assert.AreEqual("Shiva", personGroups[2].Persons[1].Name);

            _source.Add(new Person("Yien", 27));
            Assert.AreEqual(2, personGroups[0].Persons.Count);
            Assert.AreEqual("Yien", personGroups[0].Persons[1].Name);
        }
        
        [Test]
        public void SelectingViewAdapter_ByAge_ReturnsCollectionOfAges()
        {
            var ageCollection = from item in _source
                                select item.Age;

            Assert.AreEqual(6, ageCollection.Count);
            Assert.AreEqual(27, ageCollection[0]);
            Assert.AreEqual(30, ageCollection[2]);
            Assert.AreEqual(43, ageCollection[5]);

            _source.Add(new Person("Yien", 27));

            Assert.AreEqual(7, ageCollection.Count);
            Assert.AreEqual(27, ageCollection[6]);
        }

        [Test]
        public void TestViewAdapterChaining()
        {
            var personCollection = from item in _source
                                   where item.Age >= 30
                                   orderby item.Name
                                   select item.Name;                                   

            Assert.AreEqual(4, personCollection.Count);
            Assert.AreEqual("Erb", personCollection[0]);
            Assert.AreEqual("Jordan", personCollection[1]);
            Assert.AreEqual("Shiva", personCollection[2]);
            Assert.AreEqual("Steve", personCollection[3]);

            _source.Add(new Person("Yien", 27));

            Assert.AreEqual(4, personCollection.Count);

            _source.Add(new Person("Alex", 31));
            Assert.AreEqual(5, personCollection.Count);
            Assert.AreEqual("Alex", personCollection[0]);
            Assert.AreEqual("Erb", personCollection[1]);
            Assert.AreEqual("Steve", personCollection[4]);
        }

        [Test]
        public void SelectingViewAdapter_Always_SupportsReadOnlyObservableCollection()
        {
            var readOnlySource = new ReadOnlyObservableCollection<Person>(_source);
            var ageCollection = from item in readOnlySource
                                select item.Age;

            Assert.AreEqual(6, ageCollection.Count);
            Assert.AreEqual(27, ageCollection[0]);
            Assert.AreEqual(30, ageCollection[2]);
            Assert.AreEqual(43, ageCollection[5]);

            _source.Add(new Person("Yien", 27));

            Assert.AreEqual(7, ageCollection.Count);
            Assert.AreEqual(27, ageCollection[6]);
        }

        [Test]
        public void ContinuousSum_ByAge_SumsAge()
        {
            var readOnlySource = new ReadOnlyObservableCollection<Person>(_source);
            var sumOfAge = readOnlySource.Sum(x => x.Age);            
            var continuousSum = readOnlySource.ContinuousSum(x => x.Age);
            Assert.AreEqual(sumOfAge, continuousSum.CurrentValue);

            _source.Add(new Person("Peter", 12));
            Assert.AreEqual(sumOfAge + 12, continuousSum.CurrentValue);
        }

        [Test]
        public void ContinuousCount_OfAgeGreaterThan30_ReturnsCountOfPersonGreaterThan30()
        {
            var readOnlySource = new ReadOnlyObservableCollection<Person>(_source);
            var overThirty = (from item in readOnlySource
                             where item.Age > 30
                             select item).Count();


            var continuousOverThirty = (from item in readOnlySource
                                        where item.Age > 30
                                        select item).ContinuousCount();

            Assert.AreEqual(overThirty, continuousOverThirty.CurrentValue);

            _source.Add(new Person("Peter", 34));
            Assert.AreEqual(overThirty + 1, continuousOverThirty.CurrentValue);
        }

        [Test]
        public void DropReference_Always_GarbageCollectsResultCollection()
        {
            var ageCollection = from item in _source
                                select item.Age;

            // LINQ execution is deferred.  This will execute query.
            int count = ageCollection.Count();

            var weakReference = new WeakReference(ageCollection);
            Assert.IsTrue(weakReference.IsAlive);
            ageCollection = null;

            GC.Collect();
            Assert.IsFalse(weakReference.IsAlive);
        }

        private void AddItemsToSource()
        {
            _source.Add(new Person("David", 27));
            _source.Add(new Person("Mark", 15));
            _source.Add(new Person("Steve", 30));
            _source.Add(new Person("Jordan", 43));
            _source.Add(new Person("Shiva", 30));
            _source.Add(new Person("Erb", 43));

            Assert.AreEqual(6, _source.Count);
        }

        #region Person Class

        public class Person : INotifyPropertyChanged
        {
            private readonly string _name;
            private readonly int _age;

            public event PropertyChangedEventHandler PropertyChanged;

            public Person(string name, int age)
            {
                _name = name;
                _age = age;
            }

            public string Name
            {
                get { return _name; }
            }

            public int Age
            {
                get { return _age; }
            }

            #region Members                        

            public override int GetHashCode()
            {
                return (this.Name.GetHashCode() ^ this.Age.GetHashCode());
            }

            private void OnPropertyChanged(string property)
            {
                if (this.PropertyChanged == null)
                    return;

                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }

            #endregion           
        }

        #endregion
    }
}
