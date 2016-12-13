using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrahamScan.Tests
{
    public class Tests
    {
        [Test]
        public void GrahamScan_LinePoints_ShouldNotThrowEmptyStackException()
        {
            //Arrange
            var data = new Point[] { new Point(1, 1), new Point(2, 2), new Point(3, 3), new Point(4, 4) };

            //Act
            var result = GrahamScan.Process(data);

            //Assert
            Assert.IsTrue(true);
        }
    }
}
