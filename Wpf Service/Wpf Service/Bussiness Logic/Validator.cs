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


        public readonly TextBox _emailInput;


        public readonly TextBox _phoneNumberInput;


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
                if (result.Count > 0)
                {
                    if (parent != null)
                    {
                        throw new InvalidDataException("Field '" + parent.Header + "' contains errors!");
                    }

                    throw new InvalidDataException("Some fields contains errors!");
                }

                if (input.Text.Trim().Length != 0)
                {
                    continue;
                }

                if (parent != null)
                {
                    throw new InvalidDataException("Field '" + parent.Header + "' can't be empty!");
                }

                throw new InvalidDataException("Check all fields if it is filled up!");
            }

        
            ValidateEmail();
            ValidatePhoneNumber();
        }

        private void ValidateEmail()
        {
            var text = _emailInput.Text.Trim();
            if (text.Length < 1)
            {
                throw new InvalidDataException("Field 'Email' can't be empty!");
            }

            //if (!new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").IsMatch(text))
            //{
            //    throw new InvalidDataException("Incorrect email pattern!");
            //}
        }

        private void ValidatePhoneNumber()
        {
            var text = _phoneNumberInput.Text.Trim();
            if (text.Length < 1)
            {
                throw new InvalidDataException("Field 'PhoneNumber' can't be empty!");
            }

            //if (!new Regex(@"^(\d){3}\-(\d){2}\-(\d){2}\-(\d){3}$").Match(text).Success)
            //{
            //    throw new InvalidDataException("Incorrect phone number pattern, use 'xxx-xx-xx-xxx' format.");
            //}
        }
    }
}
