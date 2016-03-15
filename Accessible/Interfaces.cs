using System;
using System.IO;

namespace PKHeX
{
    namespace Accessibility
    {
        namespace Interfaces
        {
            class CrySystem
            {

                public CrySystem(string path, string extension, string prefix, int ascending, int descending)
                {
                    this.player = new MP3Player();
                    this.resourcesPath = path;
                    this.resourcesExtension = extension;
                    this.resourcesPrefix = prefix;
                    this.ascendingLimit = ascending;
                    this.descendingLimit = descending;
                    this.externalResources = AreExternal();
                }

                private bool AreExternal()
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

                public void Play(int index)
                {
                    if (externalResources)
                    {
                        player.Open(resourcesPath + index + resourcesExtension);
                    }
                    else {
                        player.Load((Byte[])Properties.Resources.ResourceManager.GetObject(resourcesPrefix + index.ToString()));
                    }
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
                private string resourcesPrefix;
                private bool externalResources;
            }

        }
    }
}
