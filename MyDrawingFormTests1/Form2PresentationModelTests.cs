using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class Form2PresentationModelTests
    {
        Model model;
        Form2PresentationModel pModel;
        PrivateObject pobj;

        String text = "test";

        [TestInitialize]
        public void Setup()
        {
            model = new Model();
            pModel = new Form2PresentationModel(text);

            pobj = new PrivateObject(pModel);
        }

        [TestMethod()]
        public void Form2PresentationModelTest()
        {
            Assert.AreEqual(false, pModel.IsConfirmEnabled);
            Assert.AreEqual(text, pobj.GetField("_text"));
        }

        [TestMethod()]
        public void TextChangedTest()
        {
            pModel.TextChanged(text);
            Assert.IsFalse(pModel.IsConfirmEnabled);
            pModel.TextChanged("test1");
            Assert.IsTrue(pModel.IsConfirmEnabled);
            pModel.TextChanged("");
            Assert.IsFalse(pModel.IsConfirmEnabled);
        }

        [TestMethod()]
        public void NotifyTest()
        {

            var eventRaised = false;
            pModel.PropertyChanged += (sender, e) =>
            {
                eventRaised = true;
            };

            Assert.IsFalse(eventRaised);

            pModel.TextChanged("test1");

            Assert.IsNotNull(pobj.GetFieldOrProperty("PropertyChanged"));
            Assert.IsTrue(eventRaised);
        }
    }
}