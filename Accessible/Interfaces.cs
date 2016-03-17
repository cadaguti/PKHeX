using Media;
using System;
using System.IO;

namespace Accessibility
    {
        namespace Interfaces
        {
            class CrySystem
            {

                public CrySystem(string path, string extension, int ascending, int descending)
                {
                    this.player = new MP3Player();
                    this.resourcesPath = path;
                    this.resourcesExtension = extension;
                    this.ascendingLimit = ascending;
                    this.descendingLimit = descending;
            }

                public bool CriesExist()
                {
                    bool exists = false;
                    if (Directory.Exists(resourcesPath))
                    {
                        for (int i = 0; i <= ascendingLimit; i++)
                        {
                            if (!File.Exists(resourcesPath + i.ToString() + resourcesExtension))
                            {
                                return false;
                            }
                        }
                        for (int i = 65535; i >= descendingLimit; i--)
                        {
                            if (!File.Exists(resourcesPath + i.ToString() + resourcesExtension))
                            {
                                return false;
                            }
                        }
                        exists = true;
                    }
                    return exists;
                }

            public void Play(string cry)
            {
                if (!File.Exists(resourcesPath + cry + resourcesExtension))
                {
                    cry = cry.Substring(0, cry.IndexOf("_"));
                }
                string filename = resourcesPath + cry + resourcesExtension;
                player.Open(filename);
                player.Play();
            }

            public void Stop()
                {
                    player.Close();
            }

                private MP3Player player;
                private string resourcesPath;
                private string resourcesExtension;
                private int ascendingLimit;
                private int descendingLimit;
        }

        }
    }
