using System.Windows.Forms;

namespace Quasar.Server.Plugin
{
    public interface IPlugin
    {
        PluginInfo Info {  get;}

        void Initialize();
        void Unload();

        Form CreateWindow();
    }
}
