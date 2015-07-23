using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medusa.BLL
{
    public class CNPJ
    {
        private string cnpjValue;
        private bool isValid;

        public string Value
        {
            get
            {
                if (String.IsNullOrEmpty(cnpjValue))
                    return String.Empty;
                else
                    return cnpjValue.Trim().Replace(".", "").Replace("-", "").Replace("/", "").Replace("_", "");
            }
            set { cnpjValue = value; }
        }

        public bool IsValid
        {
            get
            { return CNPJIsValid(); }
        }

        public CNPJ(string strCnpj)
        {
            this.cnpjValue = strCnpj;
        }

        private bool CNPJIsValid()
        {
            //verifica se o CNPJ é valido
            isValid = true;
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;

            cnpjValue = cnpjValue.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpjValue.Length != 14) return false;

            string j = cnpjValue.Substring(0, 1);
            int w = 0;
            for (int i = 0; i < 12; i++)
                if (cnpjValue[i].ToString() == j)
                    w++;
            if (w == 12)
            {
                isValid = false;
                return isValid;
            }

            tempCnpj = cnpjValue.Substring(0, 12);

            soma = 0;
            for (int i = 0; i < 12; i++) soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++) soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            if (digito != cnpjValue.Substring(12, 2)) isValid = false;

            return isValid;
        }
    }
}
