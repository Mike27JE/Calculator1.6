using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArithmeticLibrary;
using AlgebraicLibrary;
using TrigonometricLibrary;

/*Assignment 1.6
 * create a fully functional calculator which links to a maths library with a set of
 * basic arithmetic, Algebriac and trigonometry functions.
 * Libraries are :
 * Arithmetic
 *   • Addition
 *   • Subtraction
 *   • Division
 *   • Multiplication
 * Trigonemtric
 *   • Tan
 *   • Sine
 *   • Cosine
 * Algebraic  
 *   • Square Root
 *   • Cube Root
 *   • Inverse
 * 
 * By Michael Evans 
 * student ID P288106
 * 
 * Calculator1.6 Version 2
 */

namespace Calculator1._6
{
    public partial class Form1 : Form
    {
        // stores previous number entered.
        double total = 0;
        // stores recent number entered.
        double totalB = 0;
        // last operation entered.
        string pending = null;
        // records if equals button pressed since pending record last mathematical operation
        bool equalsPressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        // simply reset calculator to initial state
        public void clearAll()
        {
            total = 0;
            totalB = 0;
            txtDisplay.Clear();
            pending = null;
        }

        // checks if prior value entered by see if pending varible equals null.
        // checks if equals has been pressed.
        public void performOperation(string pending)
        {
            try
            {
                if (equalsPressed == true)
                {
                    operationSelector(pending);
                    equalsPressed = false;
                    // resets global pending to null to allow new value for total.
                    this.pending = null;
                }
                else if (!string.Equals(pending, null))
                {
                    operationSelector(pending);
                }
                else
                {
                    total = double.Parse(txtDisplay.Text);
                }
            }
            catch (FormatException)
            {
                txtDisplay.Text = "***ERROR***";
                MessageBox.Show("Invalid Opertion not a numerical value," +
                                " Please Re-Enter calculations");
                clearAll();
            }
            catch (DivideByZeroException)
            {
                txtDisplay.Text = "***ERROR***";

                if (string.Equals(pending, btnDivide.Text))
                {
                    MessageBox.Show("Invalid Opertion you can not divide by zero");
                }

                if (string.Equals(pending, btnInverse.Text))
                {
                    MessageBox.Show("Invalid Operation you can not have an inverse of zero");
                }
                clearAll();
            }
            catch (ArithmeticException)
            {
                txtDisplay.Text = "***ERROR***";

                if (string.Equals(pending, btnSquare.Text))
                {
                    MessageBox.Show("Invalid Operation square root of negative");
                }

                if (string.Equals(pending, btnTan.Text))
                {
                    MessageBox.Show("Invalid Operation Tan of 90");
                }
                clearAll();
            }
            catch (Exception)
            {
                txtDisplay.Text = "***ERROR***";
                MessageBox.Show("Error");
                clearAll();
            }
        }

        // Selects operation by matching string pending value with button text value.
        public void operationSelector(string pending)
        {
            try
            {
                totalB = double.Parse(txtDisplay.Text);
            }
            catch (FormatException e)
            {
                throw (e);
            }

            if (string.Equals(pending, btnPlus.Text))
            {
                txtDisplay.Text = "" + Arithmetic.add(total, totalB);
            }

            if (string.Equals(pending, btnTake.Text))
            {
                txtDisplay.Text = "" + Arithmetic.subtract(total, totalB);
            }

            if (string.Equals(pending, btnDivide.Text))
            {
                // Detects and handles divide by zero errors.
                if (totalB == 0)
                {
                    throw new DivideByZeroException();
                }

                txtDisplay.Text = "" + Arithmetic.divide(total, totalB);
            }

            if (string.Equals(pending, btnTimes.Text))
            {
                txtDisplay.Text = "" + Arithmetic.multiply(total, totalB);
            }

            if (string.Equals(pending, btnSquare.Text))
            {
                // Protects against square root of a negative number.
                if (totalB < 0)
                {
                    throw new ArithmeticException();
                }
                txtDisplay.Text = "" + Algebraic.squareRoot(totalB);
            }

            if (string.Equals(pending, btnCube.Text))
            {
                txtDisplay.Text = "" + Algebraic.cubeRoot(totalB);
            }

            if (string.Equals(pending, btnInverse.Text))
            {   
                // Protects against inverse of zero.
                if (totalB == 0)
                {
                    throw new DivideByZeroException();
                }

                txtDisplay.Text = "" + Algebraic.inverse(totalB);
            }

            if (string.Equals(pending, btnTan.Text))
            {
                // Checks for tan of 90 by any degree divisable by 90 and not 180.
                if (totalB % 90 == 0 && !(totalB % 180 == 0))
                {
                    throw new ArithmeticException();
                }

                txtDisplay.Text = "" + Trigonometric.tan(totalB);
            }

            if (string.Equals(pending, btnSine.Text))
            {
                txtDisplay.Text = "" + Trigonometric.sine(totalB);
            }

            if (string.Equals(pending, btnCosine.Text))
            {
                txtDisplay.Text = "" + Trigonometric.cosine(totalB);
            }

            try
            {
                total = double.Parse(txtDisplay.Text);
            }
            catch (FormatException e)
            {
                throw (e);
            }

            totalB = 0;
        }

        public void negativeHandler()
        {
            txtDisplay.Text = "-";
        }

        #region Numeric Displayed Buttons
        // Button String value is determined their text value in window forms, 
        // Changing these value will change them here.
        // number displayed in method name e.g btnOne mean button to display 1.
        private void btnOne_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnOne.Text;
        }
        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnTwo.Text;
        }
        private void btnThree_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnThree.Text;
        }
        private void btnFour_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnFour.Text;
        }
        private void btnFive_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnFive.Text;
        }
        private void btnSix_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnSix.Text;
        }
        private void btnSeven_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnSeven.Text;
        }
        private void btnEight_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnEight.Text;
        }
        private void btnNine_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnNine.Text;
        }
        private void btnZero_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnZero.Text;
        }
        private void btnDot_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = txtDisplay.Text + btnDot.Text;
        }
        #endregion

        // called when equals button pressed on calculator
        private void EqualsSign_Click(object sender, EventArgs e)
        {
            equalsPressed = true;
            performOperation(pending);
        }

        // since it calls clearAll function it won't just clear the screen but all varibles as well.
        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        #region Math Operation Buttons. 
        // Any operation having one parameter in performOperation() method 
        // must have the pending value assigned before calling performOperation().
        // methods with two are before.
        private void btnPlus_Click(object sender, EventArgs e)
        {
            performOperation(pending);
            pending = btnPlus.Text;

            txtDisplay.Clear();
        }
        // has to check for a negative value by seeing if other value are present on srceeen.
        // else it performs arthmatic operation of subtraction.
        private void btnTake_Click(object sender, EventArgs e)
        {
            if (string.Equals(txtDisplay.Text, ""))
            {
                negativeHandler();
            }
            else
            {
                performOperation(pending);
                pending = btnTake.Text;
                txtDisplay.Clear();
            }
        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            performOperation(pending);
            pending = btnDivide.Text;
            txtDisplay.Clear();
        }
        private void btnTimes_Click(object sender, EventArgs e)
        {
            performOperation(pending);
            pending = btnTimes.Text;
            txtDisplay.Clear();
        }
        private void btnSquare_Click(object sender, EventArgs e)
        {
            pending = btnSquare.Text;
            performOperation(pending);
        }
        private void btnCube_Click(object sender, EventArgs e)
        {
            pending = btnCube.Text;
            performOperation(pending);
        }
        private void btnInverse_Click(object sender, EventArgs e)
        {
            pending = btnInverse.Text;
            performOperation(pending);
        }
        private void btnTan_Click(object sender, EventArgs e)
        {
            pending = btnTan.Text;
            performOperation(pending);
        }
        private void btnSine_Click(object sender, EventArgs e)
        {
            pending = btnSine.Text;
            performOperation(pending);
        }
        private void btnCosine_Click(object sender, EventArgs e)
        {
            pending = btnCosine.Text;
            performOperation(pending);
        }
        #endregion

        // File when selcet Exit from drop down to escape porgram
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
