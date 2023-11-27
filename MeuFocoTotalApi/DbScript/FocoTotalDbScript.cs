using FirebaseAdmin.Auth;
using MeuFocoTotalApi.Model;

namespace MeuFocoTotalApi.DbScript
{
    public class FocoTotalDbScript
    {
        public Dictionary<string, object> CadastroAdd(FocoTotalCadastroModel cadastro)
        {
            string sql = $@"INSERT INTO USUARIOS(
                                            ID,
                                            USERID,
                                            USERADD,
                                            TEMPOOCORRIDO,
                                            NOMEUSUARIO,
                                            ATIVO
                                            ) VALUES (
                                            :ID,
                                            :USERID,
                                            SYSTIMESTAMP,
                                            :TEMPOOCORRIDO,
                                            :NOMEUSUARIO
                                            1
                                            )
                        RETURNING USERID INTO :USEID
                        ";
            return new Dictionary<string, object>() { { sql, cadastro } };
        }

        public string CadastroGetTodos()
        {
            return $@"SELECT * FROM USUARIOS
                      ";
        }
        public string CadastroGetTodosEmAndamento()
        {
            return $@"SELECT * FROM USUARIOS
                      WHERE ATIVO = 1";
        }

        public Dictionary<string, object> UpdateTempo(int id, int tempo)
        {
            string sql = $@"UPDATE USUARIOS SET
                      TEMPOOCORRIDO = :TEMPOOCORRIDO
                WHERE USERID = :ID AND ATIVO = 1
                ";
            return new Dictionary<string, object>() { { sql, new { USERID = id, TEMPOOCORRIDO = tempo } } }; 
        }
        public Dictionary<string, object> FinalizarTempo(int id, int tempo)
        {
            string sql = $@"UPDATE USUARIOS SET
                      TEMPOOCORRIDO = :TEMPOOCORRIDO,
                      ATIVO = 0
                WHERE USERID = :USERID AND ATIVO = 1
                ";
            return new Dictionary<string, object>() { { sql, new { USERID = id, TEMPOOCORRIDO = tempo } } };
        }

        public Dictionary<string, object> DeletarRegistro(int id)
        {
            string sql = $@"DELETE USUARIOS WHERE ID = :ID";
            return new Dictionary<string, object>() { { sql, new { ID = id } } };
        }
    }
}
