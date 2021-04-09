// Texts.cs
// decrypted by Arsenic for KG-Emulator

using System.Collections.Generic;

namespace LauncherWebzenV2.Source
{
    internal class Texts
    {
        private static string lastMessage;
        private static object[] lastParams;
        private static Dictionary<string, string> Text_Eng = new Dictionary<string, string>()
        {
            {
                "UNKNOWNERROR",
                "Could not connect to server: \n{0}"
            },
            {
                "MISSINGBINARY",
                "The game cannot be started {0} is missing."
            },
            {
                "CANNOTSTART",
                "Could not start the game!"
            },
            {
                "NONETWORK",
                "Could not connect to the server."
            },
            {
                "READINGINFO",
                "Reading launcher info..."
            },
            {
                "READINFOERROR",
                "Could not read launcher info."
            },
            {
                "READINFOCOMPLETE",
                "Loaded launcher info."
            },
            {
                "CONNECTING",
                "Connecting to the server..."
            },
            {
                "CONNECTED",
                "Connected."
            },
            {
                "LISTDOWNLOAD",
                "Downloading information from the server..."
            },
            {
                "CHECKFILE",
                "Checking {0}"
            },
            {
                "DOWNLOADFILE",
                "Downloading: {0}"
            },
            {
                "COMPLETEPROGRESS",
                "{0}%"
            },
            {
                "CURRENTPROGRESS",
                "{0}%"
            },
            {
                "CHECKCOMPLETE",
                "Check complete, files are up to date."
            },
            {
                "DOWNLOADCOMPLETE",
                "Download complete, good game."
            }
        };
        private static Dictionary<string, string> Text_Spn = new Dictionary<string, string>()
        {
            {
                "UNKNOWNERROR",
                "No se pudo conectar al servidor: \n{0}"
            },
            {
                "MISSINGBINARY",
                "El juego no se pudo iniciar porque falta {0}."
            },
            {
                "CANNOTSTART",
                "El juego no se pudo iniciar!"
            },
            {
                "NONETWORK",
                "No se pudo conectar con el servidor."
            },
            {
                "READINGINFO",
                "Leyendo información del launcher..."
            },
            {
                "READINFOERROR",
                "No se pudo leer la información del launcher."
            },
            {
                "READINFOCOMPLETE",
                "Información del launcher cargada."
            },
            {
                "CONNECTING",
                "Conectando con el servidor..."
            },
            {
                "CONNECTED",
                "Conectado."
            },
            {
                "LISTDOWNLOAD",
                "Descargando información del servidor..."
            },
            {
                "CHECKFILE",
                "Verificando {0}"
            },
            {
                "DOWNLOADFILE",
                "Descargando: {0}"
            },
            {
                "COMPLETEPROGRESS",
                "{0}%"
            },
            {
                "CURRENTPROGRESS",
                "{0}%"
            },
            {
                "CHECKCOMPLETE",
                "Verificación completa, los archivos están actualizados."
            },
            {
                "DOWNLOADCOMPLETE",
                "Descarga completa, disfruta el juego."
            }
        };
        private static Dictionary<string, string> Text_Por = new Dictionary<string, string>()
        {
            {
                "UNKNOWNERROR",
                "Não pode conectar ao servidor: \n{0}"
            },
            {
                "MISSINGBINARY",
                "O jogo não pôde ser iniciado porque está faltando {0}."
            },
            {
                "CANNOTSTART",
                "Não foi possível iniciar o jogo!"
            },
            {
                "NONETWORK",
                "Não pode conectar ao servidor."
            },
            {
                "READINGINFO",
                "Lendo informações do launcher..."
            },
            {
                "READINFOERROR",
                "A informação do launcher não pôde ser lida."
            },
            {
                "READINFOCOMPLETE",
                "As informações do launcher foram carregadas."
            },
            {
                "CONNECTING",
                "Conectando ao servidor..."
            },
            {
                "CONNECTED",
                "Conectado."
            },
            {
                "LISTDOWNLOAD",
                "Baixando informações do servidor..."
            },
            {
                "CHECKFILE",
                "Verificando {0}"
            },
            {
                "DOWNLOADFILE",
                "Baixando: {0}"
            },
            {
                "COMPLETEPROGRESS",
                "{0}%"
            },
            {
                "CURRENTPROGRESS",
                "{0}%"
            },
            {
                "CHECKCOMPLETE",
                "Verificação completa, os arquivos estão atualizados."
            },
            {
                "DOWNLOADCOMPLETE",
                "Download completo, bom jogo."
            }
        };

        public static string GetText(string Key, params object[] Arguments)
        {
            Texts.lastMessage = Key;
            Texts.lastParams = Arguments;
            switch (Import.LauncherLanguage)
            {
                case 0:
                    using (Dictionary<string, string>.Enumerator enumerator = Texts.Text_Eng.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            KeyValuePair<string, string> current = enumerator.Current;
                            if (current.Key == Key)
                                return string.Format(current.Value, Arguments);
                        }
                        break;
                    }
                case 1:
                    using (Dictionary<string, string>.Enumerator enumerator = Texts.Text_Spn.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            KeyValuePair<string, string> current = enumerator.Current;
                            if (current.Key == Key)
                                return string.Format(current.Value, Arguments);
                        }
                        break;
                    }
                case 2:
                    using (Dictionary<string, string>.Enumerator enumerator = Texts.Text_Por.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            KeyValuePair<string, string> current = enumerator.Current;
                            if (current.Key == Key)
                                return string.Format(current.Value, Arguments);
                        }
                        break;
                    }
            }
            return (string) null;
        }

        public static string ReloadString() => Texts.GetText(Texts.lastMessage, Texts.lastParams);
    }
}
