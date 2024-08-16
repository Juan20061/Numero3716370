using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Numero3716370
{
    public class LocalDbService
    {

        private const string DB_NAME = "Numero_local_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDbService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory,DB_NAME));

            //le indicamos  al sistema  que cree  la tabla de nuestro contexto
            _connection.CreateTableAsync<Signo>();
        }
        //metodo para alistar los registros de nuestra tabla
        public async Task<List<Signo>> GetSigno()
        {
            return await _connection.Table<Signo>().ToListAsync();
        }

        public async Task<Signo> GetById(int id)
        {
            return await _connection.Table<Signo>().Where(x => x.id == id).FirstOrDefaultAsync();
        }

        //Metodod para crear registros
        public async Task Create(Signo signos)
        {
            await _connection.InsertAsync(signos);
        }

        //Metodo para actualizar 
        public async Task Update(Signo signos)
        {
            await _connection.UpdateAsync(signos);
        }

        //Metodo para eliminar
        public async Task Delete(Signo signos)
        {
            await _connection.DeleteAsync(signos);
        }
    }
}
