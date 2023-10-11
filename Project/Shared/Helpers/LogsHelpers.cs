namespace Project.Shared.Helpers
{
    public static class LogsHelpers
    {
        const string arrows = ">>>";
        public static string BuildLogsHelpers<T>(string log) where T : class 
        {
            string resul = $"Date {DateTime.Now.ToLongTimeString()} {arrows} File {typeof(T)} {arrows} {log}";
            return resul;
        }

        public enum Operacion
        {
            Insert,
            Update,
            Delete,
        }

    }
}
