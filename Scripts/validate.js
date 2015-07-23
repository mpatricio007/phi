function ValidatePageGrupo(grupo,msg) {

    if (Page_ClientValidate(grupo)) {

        return confirm(msg);

    }

}

function ValidatePage(msg) {
   
    if (Page_ClientValidate()) {
        return confirm(msg);
    }
    else
        alert("Erros de preenchimento. Verifique!");

}

function Alerta(msg) {

    alert(msg);

}

function AlertaExclusao() {
    return confirm("Confirma exclusão?");
}

function maior_que_zero(source, arguments) {
    arguments.IsValid = arguments.Value > 0;
}


function valida_cpf(source, arguments) {
    var numeros, digitos, soma, i, resultado, digitos_iguais;
    var cpf = arguments.Value.toString().replace(/\./g, "").replace(/-/, "");
    digitos_iguais = 1;
    if (cpf.length < 11) {
        arguments.IsValid = false;
        return false;
    }
    for (i = 0; i < cpf.length - 1; i++)
        if (cpf.charAt(i) != cpf.charAt(i + 1)) {
            digitos_iguais = 0;
            break;
        }
    if (!digitos_iguais) {
        numeros = cpf.substring(0, 9);
        digitos = cpf.substring(9);
        soma = 0;
        for (i = 10; i > 1; i--)
            soma += numeros.charAt(10 - i) * i;
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(0)) {
            arguments.IsValid = false;
            return false;
        }
        numeros = cpf.substring(0, 10);
        soma = 0;
        for (i = 11; i > 1; i--)
            soma += numeros.charAt(11 - i) * i;
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(1)) {
            arguments.IsValid = false;
            return false;
        }
        arguments.IsValid = true;
        return false;
    }
    else {
        arguments.IsValid = false;
        return false;
    }
}

function valida_cnpj(source, arguments) {
    var numeros, digitos, soma, i, resultado, pos, tamanho, digitos_iguais;
    var cnpj = arguments.Value.toString().replace(/\./g, "").replace(/-/, "").replace(/\//g, "");
        digitos_iguais = 1;
    if (cnpj.length < 14) {
        arguments.IsValid = false;
        return false;
    }
    for (i = 0; i < cnpj.length - 1; i++)
        if (cnpj.charAt(i) != cnpj.charAt(i + 1)) {
            digitos_iguais = 0;
            break;
        }
        if (!digitos_iguais) {
            tamanho = cnpj.length - 2
            numeros = cnpj.substring(0, tamanho);
            digitos = cnpj.substring(tamanho);
            soma = 0;
            pos = tamanho - 7;
            for (i = tamanho; i >= 1; i--) {
                soma += numeros.charAt(tamanho - i) * pos--;
                if (pos < 2)
                    pos = 9;
            }
            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado != digitos.charAt(0)) {
                arguments.IsValid = false;
                return false;
            }
            tamanho = tamanho + 1;
            numeros = cnpj.substring(0, tamanho);
            soma = 0;
            pos = tamanho - 7;
            for (i = tamanho; i >= 1; i--) {
                soma += numeros.charAt(tamanho - i) * pos--;
                if (pos < 2)
                    pos = 9;
            }
            resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
            if (resultado != digitos.charAt(1)) {
                arguments.IsValid = false;
                return false;
            }
            arguments.IsValid = true;
            return true;
        }
        else {
            arguments.IsValid = false;
            return false;
        }
} 