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
               Name = "Usuário",
               NormalizedName = "USUÁRIO"
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
            }
        };
        builder.Entity<Produto>().HasData(produtos);
    }

}