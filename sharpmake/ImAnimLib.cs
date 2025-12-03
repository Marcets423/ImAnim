using System.IO;
using Sharpmake;

namespace ImAnim
{
    // ImAnim Library project
    [Generate]
    public class ImAnimLibProject : CommonProject
    {
        public ImAnimLibProject()
        {
            Name = "ImAnimLib";
            SourceRootPath = "[project.SharpmakeCsPath]/..";
            SourceFilesExtensions.Add(".h", ".cpp");
            SourceFilesExcludeRegex.Add(@"demo_im_anim\.cpp$");
        }

        public override void ConfigureAll(Configuration conf, ImAnimTarget target)
        {
            base.ConfigureAll(conf, target);

            conf.Output = Configuration.OutputType.Lib;

            // Add imgui include paths (includes imgui_internal.h)
            conf.IncludePaths.Add(Path.Combine("[project.SharpmakeCsPath]", "..", "extern", "imgui"));

            // Export include path for dependents
            conf.IncludePrivatePaths.Add("[project.SharpmakeCsPath]/..");
        }
    }
}
