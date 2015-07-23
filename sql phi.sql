insert into cliente
  ([id_cliente]
           ,[nome]
           ,[sexo]
           ,[dtNascto]
           ,[email_value]
           ,[data_cadastro]
           ,[endereco_logradouro]
           ,[endereco_numero]
           ,[endereco_complemento]
           ,[endereco_bairro]
           ,[endereco_cidade]
           ,[endereco_uf]
           ,[endereco_cep]
           ,[telefone_value]
           ,[comercial_value]
           ,[celular_value]
           ,[tel_emergencia_value]
           ,[contato_emergencia]
           ,[responsavel]
           ,[cpf]
           ,[rg]
           ,[obs]
           ,[vip]
           ,[id_usuario]
           ,[foto])
SELECT [orcamento] as id_cliente 
      ,cast([nome] as varchar(100)) as nome
	  , 'M' as sexo
	  , getdate() as dtNascto
      ,cast(email as varchar(100)) as email_value
	  ,getdate() as data_cadastro
	  ,cast(endereco as varchar(50)) as endereco_logradouro
	  ,'' as endereco_numero
	  ,'' as endereco_complemento
	  ,cast(bairro as varchar(30)) as endereco_bairro
	  ,cast(cidade as varchar(50)) as endereco_cidade
	  ,cast(uf as varchar(2)) as [endereco_uf]
	  ,cast(cep as varchar(9)) as [endereco_cep]
	  ,cast(fone as varchar(20)) [telefone_value]
	  ,cast(comercial as varchar(20)) as [comercial_value]
	  ,cast(cel as varchar(20)) as [celular_value]
	  ,cast(cel as varchar(20)) [tel_emergencia_value]
	  ,cast(nome as varchar(50)) as [contato_emergencia]
	  ,cast([responsavel] as varchar(50)) as [responsavel]
	  ,cast(cpf as varchar(14)) as cpf
	  ,cast(rg as varchar(15)) as rg
	  ,obs
	  ,0 as vip
	  ,1 as id_usuario
	  ,'' as foto
	  --,'../fotos/foto' + cast([orcamento] as varchar(50)) + '.jpg' as foto
	 
  FROM [dbo].[clientes]
GO

update Cliente set foto = '../../fotos/foto' + cast(cast(m.Chave_Cliente as bigint) as varchar(50)) + '.jpg', chave = cast(m.Chave_Cliente as bigint)  from
cliente c inner join  Matricula_cad m
on c.id_cliente = cast(m.Chave_NumeroCartao as bigint)




