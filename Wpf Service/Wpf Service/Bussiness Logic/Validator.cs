using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace Wpf_Service.Bussiness_Logic
{
	public class Validator
    {

        private readonly List<TextBox> _inputs;


        private readonly TextBox _emailInput;


        private readonly TextBox _phoneNumberInput;


        public Validator(List<TextBox> inputs, TextBox emailInput, TextBox phoneNumberInput)
        {
            _inputs = inputs;
            _emailInput = emailInput;
            _phoneNumberInput = phoneNumberInput;
        }

        public void Validate()
        {
            foreach (var input in _inputs)
            {
                var parent = input.Parent as GroupBox;
                var result = Validation.GetErrors(input);
            }
            ValidateEmail();
            ValidatePhoneNumber();
        }

        private void ValidateEmail()
        {
            var text = _emailInput.Text.Trim();
        }

        private void ValidatePhoneNumber()
        {
            var text = _phoneNumberInput.Text.Trim();
        }
    }
}
