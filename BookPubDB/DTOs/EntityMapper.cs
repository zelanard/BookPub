namespace BookPubDB.DTOs
{
    public static class EntityMapper
    {
        public static void MapDto<TDto, TEntity>(this TEntity entity, TDto dto)
        {
            if(dto == null || entity == null)
            {
                throw new ArgumentNullException(nameof(dto), "DTO and Entity cannot be null.");
            }

            var dtoProps = typeof(TDto).GetProperties();
            var entityProps = typeof(TEntity).GetProperties();

            foreach(var dtoProp in dtoProps)
            {
                var entityProp = Array.Find(entityProps, p => p.Name == dtoProp.Name && 
                    p.PropertyType == dtoProp.PropertyType);

                if(entityProp != null && entityProp.CanWrite)
                {
                    entityProp.SetValue(entity, dtoProp.GetValue(dto));
                }
            }
        }
    }
}