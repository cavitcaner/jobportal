using Microsoft.EntityFrameworkCore;

namespace JobPortal.Core.Configuration
{
    public abstract class AModelBuilder {
        public abstract void Build(ModelBuilder modelBuilder);
    }
}
