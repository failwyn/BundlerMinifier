using System;
using System.IO;
using System.Linq;
using BundlerMinifier;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BundlerMinifierTest
{
    [TestClass]
    public class Bugs
    {
        private const string TEST_BUNDLE = "../../../artifacts/bugs/test1.json";
        private const string RESULT_PATH = "../../../artifacts/bugs/";
        private BundleFileProcessor _processor;
        private string _path = string.Empty;

        [TestInitialize]
        public void Setup()
        {
            _processor = new BundleFileProcessor();
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (File.Exists(_path))
            {
                File.Delete(_path);
            }
        }

        [TestMethod, TestCategory("Bugs")]
        [Ignore]
        public void Bug6_ExpectedToFail()
        {
            _processor.Process(TEST_BUNDLE.Replace("test1", "bug6"));

            _path = $"{RESULT_PATH}bug6.min.css";
            var jsResult = File.ReadAllText(_path);
            File.Delete(_path);

            Assert.AreEqual(".bug6::before{content:\"\\f67f\"}", jsResult);
        }

        [TestMethod, TestCategory("Bugs")]
        [Ignore]
        public void Bug12_ExpectedToFail()
        {
            _processor.Process(TEST_BUNDLE.Replace("test1", "bug12"));

            _path = $"{RESULT_PATH}bug12.min.css";
            var jsResult = File.ReadAllText(_path);
            File.Delete(_path);

            Assert.AreEqual(".bug12:has(#Id){position:relative}", jsResult);
        }

        [TestMethod, TestCategory("Bugs")]
        public void Bug24()
        {
            _processor.Process(TEST_BUNDLE.Replace("test1", "bug24"));

            _path = $"{RESULT_PATH}bug24.min.css";
            var jsResult = File.ReadAllText(_path);
            File.Delete(_path);

            Assert.AreEqual(".grid-column{width:0fr}", jsResult);
        }

        [TestMethod, TestCategory("Bugs")]
        public void Bug26()
        {
            _processor.Process(TEST_BUNDLE.Replace("test1", "bug26"));

            _path = $"{RESULT_PATH}bug26.min.js";
            var jsResult = File.ReadAllText(_path);
            File.Delete(_path);

            Assert.AreEqual("var funcObject2=({param1:n,param2:t=1})=>{console.log(n),console.log(t)};", jsResult);
        }

        [TestMethod, TestCategory("Bugs")]
        [Ignore]
        public void Bug28_ExpectedToFail()
        {
            _processor.Process(TEST_BUNDLE.Replace("test1", "bug28"));

            _path = $"{RESULT_PATH}bug28.min.css";
            var jsResult = File.ReadAllText(_path);
            File.Delete(_path);

            Assert.AreEqual(".grid-column{width:0fr}", jsResult);
        }

        [TestMethod, TestCategory("Bugs")]
        [Ignore]
        public void Bug31_ExpectedToFail()
        {
            _processor.Process(TEST_BUNDLE.Replace("test1", "bug31"));

            _path = $"{RESULT_PATH}bug31.min.js";
            var jsResult = File.ReadAllText(_path);
            File.Delete(_path);

            Assert.AreEqual("function Bug31(n){if(BigInt(n)<9223372036854775808n)return!0}", jsResult);
        }
    }
}
