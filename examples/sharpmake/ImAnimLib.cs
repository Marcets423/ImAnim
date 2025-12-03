using System.IO;
using Sharpmake;

namespace ImAnim
{
    // ImAnim Library project (static lib with im_anim.h/cpp)
    [Generate]
    public class ImAnimLibProject : CommonProject
    {
        public ImAnimLibProject()
        {
            Name = "ImAnimLib";

            // Root contains im_anim.h and im_anim.cpp
            SourceRootPath = Path.Combine("[project.SharpmakeCsPath]", "..", "..");
            SourceFilesExtensions.Add(".h", ".cpp");

            // Only include im_anim files from root
            SourceFilesExcludeRegex.Add(@"demo_im_anim\.cpp$");
            SourceFilesExcludeRegex.Add(@"examples[/\\]");
            SourceFilesExcludeRegex.Add(@"docs[/\\]");
        }

        public override void ConfigureAll(Configuration conf, ImAnimTarget target)
        {
            base.ConfigureAll(conf, target);

            conf.Output = Configuration.OutputType.Lib;

            // Add imgui include paths
            conf.IncludePaths.Add(Path.Combine("[project.SharpmakeCsPath]", "..", "extern", "imgui"));

            // Export include path for dependents (root where im_anim.h lives)
            conf.IncludePrivatePaths.Add(Path.Combine("[project.SharpmakeCsPath]", "..", ".."));
        }
    }
}
