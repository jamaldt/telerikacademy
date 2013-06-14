using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystemNS;

namespace CalendarSystem.Test
{
    [TestClass]
    public class CommandTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseTestCommandWithoutArgs()
        {
            string commandInput = "AddEvent";
            Command command = Command.Parse(commandInput);
        }

        [TestMethod]
        public void ParseTestCommandWithOneArgument()
        {
            string cmd = "AddEvent";
            string arg = "arg";
            string commandInput = cmd + " " + arg;
            Command command = Command.Parse(commandInput);
            StringAssert.Equals(cmd, command.Name);
            StringAssert.Equals(arg, command.Arguments[0]);
        }

        [TestMethod]
        public void ParseTestCommandWithTwoArguments()
        {
            string cmd = "AddEvent";
            string arg1 = "arg1";
            string arg2 = "arg2";
            string commandInput = cmd + " " + arg1 + " | " + arg2;
            Command command = Command.Parse(commandInput);
            StringAssert.Equals(cmd, command.Name);
            StringAssert.Equals(arg1, command.Arguments[0]);
            StringAssert.Equals(arg2, command.Arguments[1]);
        }

        [TestMethod]
        public void ParseTestCommandWithThreeArguments()
        {
            string cmd = "AddEvent";
            string arg1 = "arg1";
            string arg2 = "arg2";
            string arg3 = "arg3";
            string commandInput = cmd + " " + arg1 + " | " + arg2 + " | " + arg3;
            Command command = Command.Parse(commandInput);
            StringAssert.Equals(cmd, command.Name);
            StringAssert.Equals(arg1, command.Arguments[0]);
            StringAssert.Equals(arg2, command.Arguments[1]);
            StringAssert.Equals(arg3, command.Arguments[2]);
        }
    }
}
