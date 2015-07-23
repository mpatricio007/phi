using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medusa.BLL
{
    public class CPF
    {
        private string cpfValue;
        private bool isValid;

        public string Value
        {
            get
            {
                if (String.IsNullOrEmpty(cpfValue))
                    return String.Empty;
                else
                    return cpfValue.Trim().Replace(".", "").Replace("-", "");
            }
            set { cpfValue = value; }
        }

        public bool IsValid
        {
            get
            { return CPFIsValid(); }
        }

        public CPF(string strCpf)
        {
            this.cpfValue = strCpf;
        }

        private bool CPFIsValid()
        {
            //verifica se o cpf é valido
            isValid = true;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            cpfValue = cpfValue.Trim().Replace(".", "").Replace("-", "");

            if (cpfValue.Length != 11)
            {
                isValid = false;
                return isValid;
            }

            string j = cpfValue.Substring(0, 1);
            int w = 0;
            for (int i = 0; i < 9; i++)
                if (cpfValue[i].ToString() == j)
                    w++;
            if (w == 9)
            {
                isValid = false;
                return isValid;
            }

            tempCpf = cpfValue.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;
            for (int i = 0; i < 10; i++) soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (digito != cpfValue.Substring(9, 2)) isValid = false;

            return isValid;
        }

    }
}
