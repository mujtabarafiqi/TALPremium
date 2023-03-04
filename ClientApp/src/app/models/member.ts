
export class MemberPremiumInput {
  public age?: number;
  public sumInsured?: number;
  public occupationId?: number;
}
export class Member extends MemberPremiumInput {
  public name?: string;
  public dateOfBirth?: Date;
}
