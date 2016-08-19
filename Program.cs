using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;


namespace WindowsAutomationAPISample
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process.Start("calc");
            Thread.Sleep(3000); //Sleep 3 sconds to wait calculator launched

            try
            {
                //Get the destkop element
                AutomationElement elemDesktop = AutomationElement.RootElement;

                //Search the Application main window by title from all children
                PropertyCondition pCondition = new PropertyCondition(AutomationElement.NameProperty, "Calculator");
                AutomationElement elemApplicationWindow = elemDesktop.FindFirst(TreeScope.Children, pCondition);

                //Search the 1 button
                AutomationElement btnOne = elemApplicationWindow.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, "1"));
                InvokePattern invokePattern1 = btnOne.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                invokePattern1.Invoke();

                AutomationElement btnPlus = elemApplicationWindow.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, "Add"));
                InvokePattern invokePatternP = btnPlus.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                invokePatternP.Invoke();

                AutomationElement btnTwo = elemApplicationWindow.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, "2"));
                InvokePattern invokePattern2 = btnTwo.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;                
                invokePattern2.Invoke();

                AutomationElement btnE = elemApplicationWindow.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, "Equals"));
                InvokePattern invokePatternE = btnE.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                invokePatternE.Invoke();

                //Verify the result by get the Name property
                AutomationElement labelResult = elemApplicationWindow.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.AutomationIdProperty, "150"));
                if (labelResult.Current.Name == "3")
                {
                    Console.WriteLine("Test case pass!");
                }
                else
                {
                    Console.WriteLine("Test case fail!");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Test case error!");
            }
        }
    }
}
