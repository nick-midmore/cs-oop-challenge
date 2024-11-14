using FluentAssertions;

namespace Challenges.Tests
{
    public class Tests
    {
        [Test]
        public void _1UserPropertyTest()
        {
            User testUser = new User("test", "test@northcoders.com");
            testUser.Username.Should().Be("test");
            testUser.Email.Should().Be("test@northcoders.com");
        }

        [Test]
        public void _2BalanceTest()
        {
            User testUser = new User("test", "test@northcoders.com");
            testUser.Balance.Should().Be(0);
        }


        [Test]
        public void _3UpdateBalanceTest()
        {
            User testUser = new User("test", "test@northcoders.com");
            testUser.UpdateBalance(55);
            testUser.Balance.Should().Be(55);
            testUser.UpdateBalance(-5);
            testUser.Balance.Should().Be(50);
        }


        [Test]
        public void _4AccountsCreatedTest()
        {
            User.ResetAccountsCount();
            User.AccountsCreated.Should().Be(0);
            new User("test1", "test1@northcoders.com");
            User.AccountsCreated.Should().Be(1);
            new User("test2", "test2@northcoders.com");
            User.AccountsCreated.Should().Be(2);
        }


        [Test]
        public void _5ItemPropertyTest()
        {
            User.ResetAccountsCount();
            Item testItem = new Item(new User("testUser", "test1@test.com"), "test", 10, "testing it out");
            testItem.Owner.Should().Be(1);
            testItem.Name.Should().Be("test");
            testItem.Price.Should().Be(10);
            testItem.Description.Should().Be("testing it out");

            //testItem.Owner = "newUser";
            //testItem.Owner.Should().Be("newUser");

            testItem.Name = "new name";
            testItem.Name.Should().Be("new name");

            testItem.Price = 20;
            testItem.Price.Should().Be(20);

            testItem.Description = "new description";
            testItem.Description.Should().Be("new description");
        }


        [Test]
        public void _6ListItemTest()
        {
            User testUser = new User("testUser", "test@northcoders.com");

            Item firstItem = Market.ListItem(new Item(testUser, "newTestItem", 20, "test description1"));
            Item firstItemForSale = Market.AllItems[0];
            firstItemForSale.Should().Be(firstItem);

            Item secondItem = Market.ListItem(new Item(testUser, "newTestItem2", 20, "test description2"));
            Item secondItemForSale = Market.AllItems[1];
            secondItemForSale.Should().Be(secondItem);
        }


        [Test]
        public void _7PurchaseItemTest()
        {
            User buyer = new User("testUser1", "test@northcoders.com");
            User seller = new User("testUser2", "test@northcoders.com");
            buyer.UpdateBalance(50);
            Market.ListItem(new Item(seller, "newTestItem", 20, "test description1"));
            Item testItem = Market.AllItems[0];
            Market.PurchaseItem(testItem, buyer, seller).Should().Be(Market.PurchaseResult.SUCCESS);
            buyer.Balance.Should().Be(30);
        }


        [Test]
        public void _9PurchaseItemWithoutFundsTest()
        {
            User seller = new User("testUser1", "test1@northcoders.com");
            Item item = Market.ListItem(new Item(seller, "newTestItem", 20, "test description1"));

            User buyer = new User("testUser2", "test2@northcoders.com");

            Market.PurchaseItem(item, buyer, seller).Should().Be(Market.PurchaseResult.INSUFFICIENT_FUNDS);

            buyer.UpdateBalance(50);

            Market.PurchaseItem(item, buyer, seller).Should().Be(Market.PurchaseResult.SUCCESS);
        }


        [Test]
        public void _9PurchaseOwnItemTest()
        {
            User seller = new User("testUser1", "test1@northcoders.com");
            seller.UpdateBalance(50);
            Item item = Market.ListItem(new Item(seller, "newTestItem", 20, "test description1"));
            Market.PurchaseItem(item, seller, seller).Should().Be(Market.PurchaseResult.ALREADY_OWNED);
        }

        [Test]
        public void _9UnlistItemTest()
        {
            User buyer = new User("testbuyer", "testbuyeremail1@test.com");
            buyer.UpdateBalance(50);
            User seller = new User("testseller", "testselleremail1@test.com");
            Item item = Market.ListItem(new Item(seller, "newTestItem", 10, "description"));
            Market.PurchaseItem(item, buyer, seller);
            Market.AllItems.Should().NotContain(item);
        }

        [Test]
        public void _12UserIdTest()
        {
            User.ResetAccountsCount();
            User user = new User("test1", "test1@test.com");
            user.UserId.Should().Be(1);
            User user2 = new User("test2", "test2@test.com");
            user2.UserId.Should().Be(2);
            User user3 = new User("test3", "test3@test.com");
            user3.UserId.Should().Be(3);
        }

        [Test]
        public void _12ItemIdTest()
        {
            Item.ResetItemsCount();
            Item item1 = new Item(new User("test1", "test1@test.com"), "nametest1", 12, "test1@test.com");
            Item item2 = new Item(new User("test2", "test2@test.com"), "nametest2", 12, "test2@test.com");
            Item item3 = new Item(new User("test3", "test3@test.com"), "nametest3", 12, "test3@test.com");

            item1.ItemId.Should().Be(1);
            item2.ItemId.Should().Be(2);
            item3.ItemId.Should().Be(3);
        }

        [Test]
        public void _13ItemOwnerTest()
        {
            User.ResetAccountsCount();
            Item item1 = new Item(new User("test1", "test1@test.com"), "nametest1", 12, "test1@test.com");
            item1.Owner.Should().Be(1);
            Item item2 = new Item(new User("test2", "test2@test.com"), "nametest2", 12, "test2@test.com");
            item2.Owner.Should().Be(2);
        }

    }
}
