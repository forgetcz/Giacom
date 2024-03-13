using Domain.Entities;
using Infrastructure.Interfaces;
using System.Data.SqlClient;

namespace Infrastructure.Data.Repository.SqlAdoNetRepository
{
    public class CrdDataRepository : IBaseDbRepository<CrdData<long>, long>
    {
        public SqlConnection? _StoreContext;

        public void setConnectionString(string connectionString)
        {
            _StoreContext = new SqlConnection(connectionString);
        }

        public async Task<long> Delete(long entity)
        {
            using (SqlCommand cmd = new SqlCommand("Delete", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = await cmd.ExecuteReaderAsync();
                CrdData<long> crdData;
                while (reader.Read())
                {
                    /*crdData = new CrdData(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)
                        , reader.GetDateTime(3), reader.GetDateTime(4), reader.GetInt32(5), reader.GetInt32(6)
                        , reader.GetString(7), reader.GetString(8));
                    */
                }
                return entity;
            }
        }

        public async Task DeleteMany(IEnumerable<long> entities)
        {
            foreach (var entity in entities)
            {
                await Delete(entity);
            }
        }

        public async Task<CrdData<long>> Insert(CrdData<long> entity)
        {
            using (SqlCommand cmd = new SqlCommand("Insert", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = await cmd.ExecuteReaderAsync();
                CrdData<long>? crdData = null;
                while (reader.Read())
                {
                    crdData = new CrdData<long>(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)
                        , reader.GetDateTime(3), reader.GetDateTime(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7), reader.GetString(8));
                }
                return crdData;
            }
        }

        public async Task<IEnumerable<CrdData<long>>> InsertMany(IEnumerable<CrdData<long>> entities)
        {
            List<CrdData<long>> result = new List<CrdData<long>>();
            foreach (var entity in entities)
            {
                var updatedEntity = await Insert(entity);
                result.Add(updatedEntity);
            }
            return result;
        }

        public async Task<IEnumerable<CrdData<long>>> ReadAll()
        {
            List<CrdData<long>> resultData = new List<CrdData<long>>();
            using (SqlCommand cmd = new SqlCommand("ReadAll", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                var reader = await cmd.ExecuteReaderAsync();
                CrdData<long> crdData = null;
                while (reader.Read())
                {
                    crdData = new CrdData<long>(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)
                        , reader.GetDateTime(3), reader.GetDateTime(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7), reader.GetString(8));
                    resultData.Add(crdData);
                }
                return resultData;
            }
        }

        public async Task<CrdData<long>?> GetById(long id)
        {
            using (SqlCommand cmd = new SqlCommand("getById", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", id);
                var reader = await cmd.ExecuteReaderAsync();
                CrdData<long>? crdData = null;
                while (reader.Read())
                {
                    crdData = new CrdData<long>(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)
                        , reader.GetDateTime(3), reader.GetDateTime(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7), reader.GetString(8));
                    return crdData;
                }
                return crdData;
            }

        }

        public async Task<CrdData<long>> Update(CrdData<long> entity)
        {
            using (SqlCommand cmd = new SqlCommand("Update", _StoreContext))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", entity.Id);
                var reader = await cmd.ExecuteReaderAsync();
                CrdData<long> crdData = null;
                while (reader.Read())
                {
                    crdData = new CrdData<long>(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)
                        , reader.GetDateTime(3), reader.GetDateTime(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetString(7), reader.GetString(8));
                    return crdData;
                }
                return crdData;
            }
        }

        public async Task<IEnumerable<CrdData<long>>> UpdateMany(IEnumerable<CrdData<long>> entities)
        {
            List<CrdData<long>> result = new List<CrdData<long>>();
            foreach (var entity in entities)
            {
                var res = await Update(entity);
                result.Add(res);
            }
            return result;
        }

        public Task<IEnumerable<CrdData<long>>> TakeRange(int skip, int count)
        {
            throw new NotImplementedException();
        }

        public Task Delete(CrdData<long> entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMany(IEnumerable<CrdData<long>> entities)
        {
            throw new NotImplementedException();
        }
    }
}
