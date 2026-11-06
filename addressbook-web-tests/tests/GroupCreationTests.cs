using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using addressbook_web_tests.model;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("NewGroup1");
            group.Header = "NewGroup1";
            group.Footer = "NewGroup1";

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Create(group);
            //app.Quit.Logout();

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Group.GetGroupList();


            app.Group.Create(group);
            //app.Quit.Logout();

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
