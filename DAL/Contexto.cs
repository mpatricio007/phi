using System;
using System.Data.Entity;

namespace Medusa.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Banco> Bancos { get; set; }     
        public DbSet<LogSistema> LogSistemas { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuPagina> MenuPaginas { get; set; }
        public DbSet<Pagina> Paginas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }        
        public DbSet<Sistema> Sistemas { get; set; }        
        public DbSet<UF> UFs { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cep> Ceps { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Plano> Planos { get; set; }
        public DbSet<Frequencia> Frequencias { get; set; }
        public DbSet<FormaPagto> FormaPagtos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<ServicoCliente> ServicoClientes { get; set; }
        public DbSet<Modalidade> Modalidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        public static Type GetPropertyType<T>(string propertyName)
        {
            Type tipoCampo = typeof(T);
            string[] Properties = propertyName.Split('.');
            foreach (var Property in Properties)
                tipoCampo = tipoCampo.GetProperty(Property).PropertyType;
            return tipoCampo;
        }      

        public Contexto()
            : base("name=Contexto")
        {
          
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new BancoConfiguration());
            modelBuilder.Configurations.Add(new LogSistemaConfiguration());
            modelBuilder.Configurations.Add(new MenuConfiguration());
            modelBuilder.Configurations.Add(new MenuPaginaConfiguration());
            modelBuilder.Configurations.Add(new PaginaConfiguration());
            modelBuilder.Configurations.Add(new SistemaConfiguration());                    
            modelBuilder.Configurations.Add(new PessoaFisicaConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new UFConfiguration());
            modelBuilder.Configurations.Add(new CidadeConfiguration());
            modelBuilder.Configurations.Add(new CepConfiguration());
            modelBuilder.Configurations.Add(new StatusConfiguration());
            modelBuilder.Configurations.Add(new PlanoConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new FrequenciaConfiguration());
            modelBuilder.Configurations.Add(new FormaPagtoConfiguration());
            modelBuilder.Configurations.Add(new ContratoConfiguration());
            modelBuilder.Configurations.Add(new PagamentoConfiguration());
            modelBuilder.Configurations.Add(new ServicoConfiguration());
            modelBuilder.Configurations.Add(new ServicoClienteConfiguration());
            modelBuilder.Configurations.Add(new ModalidadeConfiguration());
        }
    }
}