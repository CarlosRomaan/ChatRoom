//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatRoomAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChatRoom_Rooms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChatRoom_Rooms()
        {
            this.ChatRoom_Messages = new HashSet<ChatRoom_Messages>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime Date_Created { get; set; }
        public int IdState { get; set; }
    
        public virtual ChatRoom_cState ChatRoom_cState { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatRoom_Messages> ChatRoom_Messages { get; set; }
    }
}
