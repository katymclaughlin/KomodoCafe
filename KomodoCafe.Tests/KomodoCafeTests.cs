using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KomodoCafe.Data;
using KomodoCafe.Repository;

namespace KomodoCafe.Tests
{
    [TestClass]

    public class KomodoCafeTests
    {
        [TestMethod]

        public void AddtoMenu_ShouldGetCorrectBoolean()
        {
           // Arrange
        KomodoCafeData komodoCafeData= new KomodoCafeData();
        KomodoCafeRepository repository = new KomodoCafeRepository();
        // Act
        bool addResult = repository.AddMenuItem(komodoCafeData);
        // Assert
        Assert.IsTrue(addResult); 
        }

    [TestMethod]
    public void ReturnCorrectCollection()
    {
        // Arrange
        KomodoCafeData komodoCafeData= new KomodoCafeData();
        KomodoCafeRepository repository = new KomodoCafeRepository();

        repository.AddMenuItem(komodoCafeData);
        // Act
        List<KomodoCafeData> komodoCafeDatas = repository.GetMenuList();

        bool directoryHasContent = komodoCafeDatas.Contains(komodoCafeData);

        // Assert
        Assert.IsTrue(directoryHasContent);
    }

    private KomodoCafeData _komodoCafeData;

    private KomodoCafeRepository _repo;

     [TestInitialize]
    public void Arrange()
    {
        _repo = new KomodoCafeRepository();
        _komodoCafeData = new KomodoCafeData(3, "Meal Name", "Meal Description", "Ingredients List", 3.99);
        KomodoCafeData komodoCafeData = new KomodoCafeData (3, "Big Mac", "Hamburger, Fries, Coke", "bread, burger, lettuce, mayo, cheese, fries, soda", 8.99);
        _repo.AddMenuItem(_komodoCafeData);
        _repo.AddMenuItem(komodoCafeData);
    }

    [TestMethod]
    public void UpdateExistingMenuItem_ShouldReturnTrue()
    {
        // Arrange
        KomodoCafeData updatedValue = new KomodoCafeData(3, "mealName", "meal description", "ingredients list", 4.99);
        // Act
        bool updateResult = _repo.UpdateExistingMenuItem(3, 3, "updatedValue");

        // Assert
        Assert.IsTrue(updateResult);
    }    

    /*[TestMethod]
    public void DeleteExistingContent_ShouldReturnTrue()
    {
        // Arrange
        KomodoCafeData komodoCafeData = _repo.(int id);

        // Act
        bool removeResult = _repo.RemoveMealFromList(komodoCafeData);

        // Assert
        Assert.IsTrue(removeResult);
    }*/
    }
}