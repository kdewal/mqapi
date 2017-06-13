using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace DatabaseService.Models {

  public class User {
      public string Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string PanNumber { get; set; }
      public string Address1 { get; set; }
      private string _address2 = null;
      public string Address2
      {
          get { return _address2; }
          set
          {
              if (string.IsNullOrWhiteSpace(value))
              {
                  _address2 = null;
              }
              else
              {
                  _address2 = value;
              }
          }
      }
      public string City { get; set; }
      public string State { get; set; }
      public string PostalCode { get; set; }
      public string PrimaryPhone { get; set; }
      private string _secondaryPhone = null;
      public string SecondaryPhone
      {
          get
          {
              return _secondaryPhone;
          }
          set
          {
              if (string.IsNullOrWhiteSpace(value))
              {
                  _secondaryPhone = null;
              }
              else
              {
                  _secondaryPhone = value;
              }
          }
      }
      public string Email { get; set; }
      public string HashedPassword { get; set; }
  }

  public class AuthenticatedUser
  {
      public string Id { get; set; }
      public string PrimaryPhone { get; set; }
      public string HashedPassword { get; set; }
  }
  public class RegisterSuccess
  {
      public int value { get; set; }
  }
}
