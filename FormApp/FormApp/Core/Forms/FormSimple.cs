﻿using FormApp.Core.Forms;
using FormApp.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp.Core.Forms
{
    abstract public class FormSimple : Form
    {
        protected FormSimple() : base() { }
        protected FormSimple(Color color) : base(color) { }

        abstract public override double Area
        {
            get;
        }


        protected override string ToJsonSpecific()
        {
            return "\"specificData\":{" + ToJsonSpecificMore()+"}" ;
        }

        abstract protected string ToJsonSpecificMore();
    }
}
