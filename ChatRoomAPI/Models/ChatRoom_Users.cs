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
    
    public partial class ChatRoom_Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChatRoom_Users()
        {
            this.ChatRoom_Messages = new HashSet<ChatRoom_Messages>();
        }
    
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public System.DateTime Date_Created { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Country { get; set; }
        public int IdState { get; set; }
        public string AccessToken { get; set; }
    
        public virtual ChatRoom_cState ChatRoom_cState { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChatRoom_Messages> ChatRoom_Messages { get; set; }
    }
}
