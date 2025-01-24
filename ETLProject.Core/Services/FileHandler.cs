namespace ETLProject.Core.Services
{
    public abstract class FileHandler
    {
        protected readonly string filePath;
        protected FileHandler(string filepath)
        {
            this.filePath = filepath;
        }
    }
}
