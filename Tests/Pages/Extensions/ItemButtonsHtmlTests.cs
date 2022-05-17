using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Tests.Pages.Extensions {
    [TestClass] public class ItemButtonsHtmlTests: TypeTests {
        [TestMethod] public void ItemButtonsTest() => isInconclusive();
    }    
    [TestClass] public class MyBtnHtmlTests : TypeTests {
        [TestMethod] public void MyBtnTest() => isInconclusive();
    }
    [TestClass] public class MyDropDownForHtmlTests : TypeTests {
        [TestMethod] public void MyDropDownForTest() => isInconclusive();
    }
    [TestClass] public class MyEditorForHtmlTests : TypeTests {
        [TestMethod] public void MyEditorForTest() => isInconclusive();
    }
    [TestClass] public class MyIndexerForHtmlTests : TypeTests {
        [TestMethod] public void MyEditorForIndexTableHeadTest() => isInconclusive();
        [TestMethod] public void MyEditorForIndexTableBodyTest()=>isInconclusive();
    }
    [TestClass] public class MyTabHrdHtmlTests : TypeTests { 
        [TestMethod] public void MyTabHdrTest()=>isInconclusive();
    }
    [TestClass] public class MyViewerForHtmlTests : TypeTests {
        [TestMethod] public void MyViewerForTest() => isInconclusive();
    }
    [TestClass] public class ShowTableHtmlTests : TypeTests {
        [TestMethod] public void ShowTableTest() => isInconclusive();
    }

}
