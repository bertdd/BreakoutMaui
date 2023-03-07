internal class Student
{
  internal string FirstName { get; set; }
  internal string LastName { get; set; }
  internal string Address { get; set; }
  internal string PostCode { get; set; }
  internal string Place { get; set; }
  internal string Telephone { get; set; }
  internal string BirthDate { get; set; }
  public int Id { get; internal set; }

  private float slaapUren;
  internal float Slaap(float uren)
  {
    slaapUren = slaapUren + uren;
    return slaapUren;
  }
}
