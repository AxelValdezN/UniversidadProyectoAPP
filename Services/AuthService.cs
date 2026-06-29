using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace app_to_do.Services
{
    public class AuthService
    {
        private readonly string _connectionString;

        public AuthService(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("MySqlConnection");
        }

        public bool ValidarUsuario(string usuario, string password)
        {
            using var conn = new MySqlConnection(_connectionString);

            conn.Open();

            string sql =
                @"SELECT COUNT(*)
                  FROM tbl_usuarios
                  WHERE usr=@usr
                  AND pwd=@pwd";

            using var cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@usr", usuario);
            cmd.Parameters.AddWithValue("@pwd", password);

            int total = Convert.ToInt32(cmd.ExecuteScalar());

            return total > 0;
        }
    }
}

