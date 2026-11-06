using addressbook_web_tests.model;
using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading;

namespace addressbook_web_tests.tests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            EnsureGroupExists();
            
            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Remove(0);
            //app.Quit.Logout();

            List<GroupData> newGroups = app.Group.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
