using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestHellTriangleB2W
{
    [TestClass]
    public class UnitHellTriangle
    {
        int[][] triangle = {
                new int[] { 6 },
                new int[] { 3, 5 },
                new int[] { 9, 7, 1 },
                new int[] { 4, 6, 8, 4 },
            };

        [TestMethod]
        public void TestSuccess()
        {
           Int32 resultSucess = 26;
           Int32 resultMethod = HellTriangleB2WApp.Program.UserLinq(triangle);
           Assert.IsTrue(resultSucess == resultMethod);
        }

    }
}
