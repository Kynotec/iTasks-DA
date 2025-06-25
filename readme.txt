Alexandre Almeida - 2211867

Miguel Silva - 2231683

Dinis Ruivo - 2231436


1º Ir ao Ficheiro Program.cs, remover os comentários e correr o programa.(Depois de correr o programa voltar a meter os comentários para não duplicar os dados na base de dados)

Descomentar o seguinte código:
 /*
           
            using (var db = new TarefaContext())
            {
                var admin = new Gestor { nome = "admin", username = "admin" , password = "admin"};
                db.Gestores.Add(admin);
               
                var programador = new Programador { nome = "programador1", username = "programador1", password = "programador1", gestor=admin, nivelExperiencia= nivelExperiencia.Junior };
                db.Programadores.Add(programador);

                var tipotarefa = new TipoTarefa { nome = "limpar pc"};
                db.TipoTarefas.Add(tipotarefa);

                db.SaveChanges(); 
            }*/


2º Os dados de login do gestor são admin/admin e os dados do programador são programador1/programador1

