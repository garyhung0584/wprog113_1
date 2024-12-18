using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyDrawingForm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDrawingForm.Tests
{
    [TestClass()]
    public class PresentationModelTests
    {
        public Model model;
        public PresentationModel pModel;

        [TestInitialize]
        public void Setup()
        {
            this.model = new Model();
            this.pModel = new PresentationModel(this.model);
        }

        [TestMethod]
        public void TestInitialProperties()
        {
            Assert.IsFalse(pModel.IsCreateEnabled);
            Assert.IsFalse(pModel.IsStartChecked);
            Assert.IsFalse(pModel.IsTerminatorChecked);
            Assert.IsFalse(pModel.IsProcessChecked);
            Assert.IsFalse(pModel.IsDecisionChecked);
            Assert.IsFalse(pModel.IsSelectChecked);
        }

        [TestMethod()]
        public void ModelTest()
        {
            pModel.SetSelectMode();
            // Assert
            Assert.AreEqual(pModel.model, model);
        }

        [TestMethod()]
        public void NotifyTest()
        {
            // Act
            PrivateObject pobj = new PrivateObject(pModel);

            var eventRaised = false;
            pModel.PropertyChanged += (sender, e) =>
            {
                eventRaised = true;
            };

            Assert.IsFalse(eventRaised);
            pModel.NameTextBoxTextChanged("TestName");
            // Assert
            Assert.IsNotNull(pobj.GetFieldOrProperty("PropertyChanged"));
            Assert.IsTrue(eventRaised);
        }

        [TestMethod()]
        public void CurrentCursorTest()
        {
            pModel.SetSelectMode();
            // Assert
            Assert.AreEqual(pModel.CurrentCursor, System.Windows.Forms.Cursors.Default);
        }

        [TestMethod()]
        public void SetStartModeTest()
        {
            // Act
            pModel.SetStartMode();

            // Assert
            Assert.IsTrue(pModel.IsStartChecked);
        }

        [TestMethod()]
        public void SetTerminatorModeTest()
        {
            // Act
            pModel.SetTerminatorMode();

            // Assert
            Assert.IsTrue(pModel.IsTerminatorChecked);
        }

        [TestMethod()]
        public void SetProcessModeTest()
        {
            // Act
            pModel.SetProcessMode();

            // Assert
            Assert.IsTrue(pModel.IsProcessChecked);
        }

        [TestMethod()]
        public void SetDecisionModeTest()
        {
            // Act
            pModel.SetDecisionMode();

            // Assert
            Assert.IsTrue(pModel.IsDecisionChecked);
        }

        [TestMethod()]
        public void SetSelectModeTest()
        {
            // Act
            pModel.SetSelectMode();

            // Assert
            Assert.AreEqual(model.GetDrawingMode(), "");
        }

        [TestMethod()]
        public void UpdateStateTest()
        {
            pModel.SetSelectMode();
            pModel.UpdateState();

            Assert.IsTrue(pModel.IsSelectChecked);

            pModel.SetDecisionMode();
            pModel.UpdateState();

            Assert.IsTrue(pModel.IsDecisionChecked);
        }

        [TestMethod()]
        public void NameTextBoxTextChangedTest()
        {
            pModel.NameTextBoxTextChanged("");
            Assert.IsFalse(pModel.IsNameValid());
            Assert.AreEqual(Color.Red, pModel.NameLabelColor);

            pModel.NameTextBoxTextChanged("test");
            Assert.IsTrue(pModel.IsNameValid());
            Assert.AreEqual(Color.Black, pModel.NameLabelColor);

            pModel.NameTextBoxTextChanged("");
            Assert.IsFalse(pModel.IsNameValid());
        }

        [TestMethod()]
        public void XTextBoxTextChangedTest()
        {
            pModel.XTextBoxTextChanged("");
            Assert.IsFalse(pModel.IsXValid());
            Assert.AreEqual(Color.Red, pModel.XLabelColor);

            pModel.XTextBoxTextChanged("12");
            Assert.IsTrue(pModel.IsXValid());
            Assert.AreEqual(Color.Black, pModel.XLabelColor);

            pModel.XTextBoxTextChanged("a");
            Assert.IsFalse(pModel.IsXValid());
        }

        [TestMethod()]
        public void YTextBoxTextChangedTest()
        {
            pModel.YTextBoxTextChanged("");
            Assert.IsFalse(pModel.IsYValid());
            Assert.AreEqual(Color.Red, pModel.YLabelColor);

            pModel.YTextBoxTextChanged("12");
            Assert.IsTrue(pModel.IsYValid());
            Assert.AreEqual(Color.Black, pModel.YLabelColor);

            pModel.YTextBoxTextChanged("a");
            Assert.IsFalse(pModel.IsYValid());
        }

        [TestMethod()]
        public void HeightTextBoxTextChangedTest()
        {
            pModel.HeightTextBoxTextChanged("");
            Assert.IsFalse(pModel.IsHeightValid());
            Assert.AreEqual(Color.Red, pModel.HeightLabelColor);

            pModel.HeightTextBoxTextChanged("12");
            Assert.IsTrue(pModel.IsHeightValid());
            Assert.AreEqual(Color.Black, pModel.HeightLabelColor);

            pModel.HeightTextBoxTextChanged("a");
            Assert.IsFalse(pModel.IsHeightValid());
        }

        [TestMethod()]
        public void WidthTextBoxTextChangedTest()
        {
            pModel.WidthTextBoxTextChanged("");
            Assert.IsFalse(pModel.IsWidthValid());
            Assert.AreEqual(Color.Red, pModel.WidthLabelColor);

            pModel.WidthTextBoxTextChanged("12");
            Assert.IsTrue(pModel.IsWidthValid());
            Assert.AreEqual(Color.Black, pModel.WidthLabelColor);

            pModel.WidthTextBoxTextChanged("a");
            Assert.IsFalse(pModel.IsWidthValid());
        }

        [TestMethod()]
        public void ShapeAddComboBoxSelectedIndexChangedTest()
        {
            pModel.ShapeAddComboBoxSelectedIndexChanged("test");
            Assert.IsFalse(pModel.IsShapeValid());

            pModel.ShapeAddComboBoxSelectedIndexChanged("Start");
            Assert.IsTrue(pModel.IsShapeValid());
        }

        [TestMethod()]
        public void IsShapeValidTest()
        {
            pModel.ShapeAddComboBoxSelectedIndexChanged("test");
            Assert.IsFalse(pModel.IsShapeValid());

            pModel.ShapeAddComboBoxSelectedIndexChanged("Start");
            Assert.IsTrue(pModel.IsShapeValid());

            pModel.ShapeAddComboBoxSelectedIndexChanged("Terminator");
            Assert.IsTrue(pModel.IsShapeValid());

            pModel.ShapeAddComboBoxSelectedIndexChanged("Process");
            Assert.IsTrue(pModel.IsShapeValid());

            pModel.ShapeAddComboBoxSelectedIndexChanged("Decision");
            Assert.IsTrue(pModel.IsShapeValid());
        }

        [TestMethod()]
        public void CreateBlockChangedTest()
        {
            pModel.NameTextBoxTextChanged("test");
            pModel.XTextBoxTextChanged("1");
            pModel.YTextBoxTextChanged("1");
            pModel.HeightTextBoxTextChanged("1");
            pModel.WidthTextBoxTextChanged("1");
            pModel.ShapeAddComboBoxSelectedIndexChanged("Start");
            Assert.IsTrue(pModel.IsCreateEnabled);

            pModel.NameTextBoxTextChanged("test");
            pModel.XTextBoxTextChanged("a");
            pModel.YTextBoxTextChanged("1");
            pModel.HeightTextBoxTextChanged("1");
            pModel.WidthTextBoxTextChanged("1");
            pModel.ShapeAddComboBoxSelectedIndexChanged("Start");
            Assert.IsFalse(pModel.IsCreateEnabled);

            pModel.NameTextBoxTextChanged("test");
            pModel.XTextBoxTextChanged("1");
            pModel.YTextBoxTextChanged("b");
            pModel.HeightTextBoxTextChanged("1");
            pModel.WidthTextBoxTextChanged("1");
            pModel.ShapeAddComboBoxSelectedIndexChanged("Start");
            Assert.IsFalse(pModel.IsCreateEnabled);

            pModel.NameTextBoxTextChanged("test");
            pModel.XTextBoxTextChanged("1");
            pModel.YTextBoxTextChanged("1");
            pModel.HeightTextBoxTextChanged("c");
            pModel.WidthTextBoxTextChanged("1");
            pModel.ShapeAddComboBoxSelectedIndexChanged("Start");
            Assert.IsFalse(pModel.IsCreateEnabled);

            pModel.NameTextBoxTextChanged("test");
            pModel.XTextBoxTextChanged("1");
            pModel.YTextBoxTextChanged("1");
            pModel.HeightTextBoxTextChanged("1");
            pModel.WidthTextBoxTextChanged("d");
            pModel.ShapeAddComboBoxSelectedIndexChanged("Start");
            Assert.IsFalse(pModel.IsCreateEnabled);

            pModel.NameTextBoxTextChanged("test");
            pModel.XTextBoxTextChanged("1");
            pModel.YTextBoxTextChanged("1");
            pModel.HeightTextBoxTextChanged("1");
            pModel.WidthTextBoxTextChanged("1");
            pModel.ShapeAddComboBoxSelectedIndexChanged("wrong");
            Assert.IsFalse(pModel.IsCreateEnabled);
        }

        [TestMethod()]
        public void AddShapeTest()
        {
            pModel.NameTextBoxTextChanged("test");
            pModel.XTextBoxTextChanged("1");
            pModel.YTextBoxTextChanged("1");
            pModel.HeightTextBoxTextChanged("1");
            pModel.WidthTextBoxTextChanged("1");
            pModel.ShapeAddComboBoxSelectedIndexChanged("Start");
            pModel.AddShape();

            Assert.AreEqual(model.GetShapes().Count, 1);
        }
    }
}
