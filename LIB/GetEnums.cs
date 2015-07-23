
#region Libraries
using System;
using System.Collections;
using System.Collections.Generic;
#endregion Libraries

#region Definição de Labels para Enums
[AttributeUsage(AttributeTargets.All)]
public class LabelAttribute : Attribute
{

    public readonly String Label;

    public LabelAttribute(String label)
    {
        Label = label;
    }

    /// <summary>
    /// Retorna Label do <see cref="Enum" />.
    /// </summary>
    /// <param name="e">Enum</param>
    /// <returns>String com o Label do Enum</returns>
    public static String FromMember(object o)
    {
        try
        {
            return ((LabelAttribute)o.GetType().GetMember(o.ToString())[0].GetCustomAttributes(typeof(LabelAttribute), false)[0]).Label;
        }
        catch 
        {
            return String.Empty;
        }
    }

    /// <summary>
    /// Retorna tipo do <see cref="Enum" />.
    /// </summary>
    /// <param name="e">Enum</param>
    /// <returns>String com a Tipo</returns>
    public static String FromType(object o)
    {
        try
        {
            return ((LabelAttribute)o.GetType().GetCustomAttributes(typeof(LabelAttribute), false)[0]).Label;
        }
        catch 
        {
            return String.Empty;
        }
    }

    /// <summary>
    /// Converte o tipo <see cref="Enum" /> para um objeto compatível <see cref="IList" />.
    /// </summary>
    /// <param name="type">O tipo (typeof())<see cref="Enum"/>.</param>
    /// <returns>Um <see cref="IList"/> contendo o tipo valor (Key) do enumerador e a descrição (Value). 
    /// ex: DDL.DataSource = LabelAttribute.ToList(typeof(<see cref="Enum"/>));
    ///   DDL.DataTextField = "Value";
    ///   DDL.DataValueField = "Key";
    ///   DDL.DataBind();</returns>
    public static IList ToList(Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException("type");
        }

        ArrayList list = new ArrayList();
        Array enumValues = Enum.GetValues(type);

        foreach (Enum value in enumValues)
        {
            list.Add(new KeyValuePair<Enum, String>(value, FromMember(value)));
        }

        return list;
    }

    /// <summary>
    /// Retorna um In32 com o Enumerador correspondente ao valor passado
    /// </summary>
    /// <param name="type">Typo do Enumerador</param>
    /// <param name="value">Valor a procurar</param>
    /// <returns>Valor do enumerador</returns>
    public static Int32 GetValue(Type type, String value)
    {
        if (type == null)
        {
            throw new ArgumentNullException("type");
        }
        return (Int32)Enum.Parse(type, value, true);
    }

}
#endregion Definição de Labels para Enums

namespace Medusa.LIB
{

    #region GetEnums Class
    /// <summary>
    /// Summary description for GetEnums
    /// </summary>
    public static class GetEnums
    {
    }
    #endregion GetEnums Class

}