using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class MoveCheckerBFSTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void findArraySizeTestWith2Stamina()
        {
            MoveCheckerBFS bfs = new MoveCheckerBFS();

            Assert.AreEqual(13, bfs.findArraySize(2));
        }

        [Test]
        public void findArraySizeTestWith3Stamina()
        {
            MoveCheckerBFS bfs = new MoveCheckerBFS();

            Assert.AreEqual(25, bfs.findArraySize(3));
        }


    }

}
