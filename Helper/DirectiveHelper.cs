using HepsiBuradaMarsRover.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HepsiBuradaMarsRover.Helper
{
    public class DirectiveHelper
    {
        public DirectiveControl CheckDirective(string robotDirective)
        {
            DirectiveControl directiveControl = new DirectiveControl();
            directiveControl.IsSuccess = false;

            string directives = robotDirective.Trim();
            List<char> directiveList = GetDirectiveList();

            foreach (char directive in directives)
            {
                if (!directiveList.Contains(directive))
                {
                    directiveControl.Message = "Unknown Directive Supplied. Accepted values are L,M,R";
                    return directiveControl;
                }
                    
            }

            directiveControl.IsSuccess = true;
            return directiveControl;
        }

        public List<char> GetDirectiveList()
        {
            List<char> directiveList = new List<char>();
            directiveList.Add('L');
            directiveList.Add('R');
            directiveList.Add('M');

            return directiveList;
        }
    }
}
