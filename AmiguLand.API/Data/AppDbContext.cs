using AmiguLand.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AmiguLand.API.Data;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedUsuarioPadrao(builder);
        SeedCategoriaPadrao(builder);
        SeedProdutoPadrao(builder);
    }

    private static void SeedUsuarioPadrao(ModelBuilder builder)
    {
        #region Populate Roles - Perfis de Usuário
        List<IdentityRole> roles =
        [
            new IdentityRole() {
               Id = "0b44ca04-f6b0-4a8f-a953-1f2330d30894",
               Name = "Administrador",
               NormalizedName = "ADMINISTRADOR"
            },
            new IdentityRole() {
               Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
               Name = "Cliente",
               NormalizedName = "CLIENTE"
            },
        ];
        builder.Entity<IdentityRole>().HasData(roles);
        #endregion

        #region Populate Usuário
        List<Usuario> usuarios = [
            new Usuario(){
                Id = "ddf093a6-6cb5-4ff7-9a64-83da34aee005",
                Email = "bgs.ana08@gmail.com",
                NormalizedEmail = "BGS.ANA08@GMAIL.COM",
                UserName = "bgs.ana08@gmail.com",
                NormalizedUserName = "BGS.ANA08@GMAIL.COM",
                LockoutEnabled = true,
                EmailConfirmed = true,
                Nome = "Ana Lívia Borges da Silva",
                DataNascimento = DateTime.Parse("05/08/1981"),
                Foto = "/img/usuarios/avatar.png"
            }
        ];
        foreach (var user in usuarios)
        {
            PasswordHasher<Usuario> pass = new();
            user.PasswordHash = pass.HashPassword(user, "123456");
        }
        builder.Entity<Usuario>().HasData(usuarios);
        #endregion

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles =
        [
            new IdentityUserRole<string>() {
                UserId = usuarios[0].Id,
                RoleId = roles[0].Id
            }
        ];
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }

    private static void SeedCategoriaPadrao(ModelBuilder builder)
    {
        List<Categoria> categorias = new()
        {
            new Categoria()
            {
                Id = 1,
                Nome = "Personagens",
                Foto = null,
                Cor = "#88c5e4"
            },

            new Categoria()
            {
                Id = 2,
                Nome = "Animais",
                Foto = null,
                Cor = "#ac70e1"
            },

            new Categoria()
            {
                Id = 3,
                Nome = "Letras",
                Foto = null,
                Cor = "#f695b9"
            },
            
            new Categoria()
            {
                Id = 4,
                Nome = "Outros",
                Foto = null,
                Cor = "#95f6ccff"
            }
        };
        builder.Entity<Categoria>().HasData(categorias);
    }

    private static void SeedProdutoPadrao(ModelBuilder builder)
    {
        List<Produto> produtos = new()
        {
            new Produto()
            {
                Id = 1,
                CategoriaId = 1,
                Nome = "Casalzinho Snoopy",
                Descricao = "Amor em forma de amigurumi! Casalzinho Snoopy disponível na AmiguLand — feito à mão pra derreter corações",
                Qtde = 1,
                ValorCusto = 32.5M,
                ValorVenda = 34.0M,
                Foto = "/img/produtos/casalSnoopy.jpg"
            },

            new Produto()
            {
                Id = 2,
                CategoriaId = 1,
                Nome = "Chewbacca",
                Descricao = "Direto de uma galáxia muito, muito distante… Chewbacca chegou em versão chaveirinho amigurumi! Perfeito pra levar a Força geek sempre com você. Encomendas abertas! ",
                Qtde = 1,
                ValorCusto = 18.5M,
                ValorVenda = 20.0M,
                Foto = "/img/produtos/chewbacca.jpg"
            },

            new Produto()
            {
                Id = 3,
                CategoriaId = 2,
                Nome = "Coelhinho",
                Descricao = "Coelhinho estiloso com esse chapéuzinho fofo! Encomendas abertas!",
                Qtde = 1,
                ValorCusto = 15.5M,
                ValorVenda = 18.0M,
                Foto = "/img/produtos/coelhinho.jpg"
            },

            new Produto()
            {
                Id = 4,
                CategoriaId = 1,
                Nome = "Lotso",
                Descricao = "Lotso, direto do Toy Story pra AmiguLand! Fofo demais pra ser vilão. Feito à mão com carinho, encomendas abertas",
                Qtde = 1,
                ValorCusto = 45.5M,
                ValorVenda = 55.0M,
                Foto = "/img/produtos/lotso.jpg"
            },

            new Produto()
            {
                Id = 5,
                CategoriaId = 3,
                Nome = "Iniciais MC",
                Descricao = "Novidade na AmiguLand!! Agora você pode ter um chaveiro com a sua inicial",
                Qtde = 1,
                ValorCusto = 8M,
                ValorVenda = 15.0M,
                Foto = "/img/produtos/letrasMC.jpg"
            },

            new Produto()
            {
                Id = 6,
                CategoriaId = 1,
                Nome = "Sulley Plush",
                Descricao = "Fofura em versão pelúcia!",
                Qtde = 1,
                ValorCusto = 45.5M,
                ValorVenda = 55.0M,
                Foto = "/img/produtos/Sulley plush.jpg"
            },

            new Produto()
            {
                Id = 7,
                CategoriaId = 1,
                Nome = "Sulley",
                Descricao = "Fofura em versão chaveiro!",
                Qtde = 1,
                ValorCusto = 35.5M,
                ValorVenda = 40.0M,
                Foto = "/img/produtos/Sulley.jpg"
            },

            new Produto()
            {
                Id = 8,
                CategoriaId = 1,
                Nome = "Patinho com faquinha",
                Descricao = "Fofo? Sim. Ameaçador? Talvez. Patinho com faquinha na mão!",
                Qtde = 1,
                ValorCusto = 10.5M,
                ValorVenda = 15.0M,
                Foto = "/img/produtos/Patinho com faquinha.jpg"
            },
        };
        builder.Entity<Produto>().HasData(produtos);
    }

}