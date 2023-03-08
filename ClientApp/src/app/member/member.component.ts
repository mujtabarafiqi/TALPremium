import { Component, OnInit, ViewChild } from '@angular/core';
import { Member, MemberPremiumInput } from '../models/member';
import { NgForm } from '@angular/forms';
import { Occupation } from '../models/occupation';
import { OccupationServiceService } from '../services/occupation-service.service';
import { Subject } from 'rxjs/internal/Subject';
import { takeUntil } from 'rxjs/internal/operators/takeUntil';
import { MemberServiceService } from '../services/member-service.service';
import { Premium } from '../models/premium';

@Component({
  selector: 'app-member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.css']
})
export class MemberComponent implements OnInit {
  @ViewChild('memberForm') public memberForm!: NgForm;
  member: Member = {
    age: undefined,
    dateOfBirth: undefined,
    name: undefined,
    occupationId: undefined,
    sumInsured: undefined
  }
  occupations: Occupation[] = [];
  errorMessage: string = '';
  premium: Premium = {
    deathPremium: undefined,
    tpdMonthlyPremium: undefined
  };
  minDob: string = '';
  private ngUnsubscribe: Subject<boolean> = new Subject<boolean>();
  constructor(private occupationService: OccupationServiceService, private memberService: MemberServiceService) {

  }


  ngOnInit(): void {
    // Restrict date picker to 70 years dob max
    this.setMinDob();

    // Get all occupations to fill dropdown
    this.getOccupations();
  }

  setMinDob() {
    let currentDate = new Date();
    currentDate.setFullYear(currentDate.getFullYear() - 70);
    this.minDob = currentDate.getFullYear() + '-' + this.padZeroes(currentDate.getMonth() + 1) + '-' + this.padZeroes(currentDate.getDate());
  }
  getOccupations() {
    this.occupationService.getAllOccupations().pipe(takeUntil(this.ngUnsubscribe)).subscribe({
      next: result => {
        this.occupations = result;
      },
      error: error => {
        console.error(error);
        this.errorMessage = error?.message || 'Sorry, something went wrong!';
      }
    });
  }

  calculateAge() {
    // Get milliseconds of dob
    let dobTime = new Date(this.member.dateOfBirth + '')?.getTime();
    // Get diff in milliseconds and parse as date
    const ageDiff = new Date(new Date().getTime() - dobTime);
    // Offset unix epoch and round off to two decimal places
    this.member.age = Math.abs(ageDiff.getUTCFullYear() - 1970);
    //this.member.age = Math.round((ageDiff.getUTCFullYear() - 1970 + ((ageDiff.getMonth() + 1) / 12)) * 100) / 100;
  }
  calculatePremium() {
    if (this.memberForm.invalid) {
      this.errorMessage = "Please fill in all the details.";
      return;
    }
    else if (Number(this.member.age) > 70) {
      this.errorMessage = "Age must be 70 years max.";
      return;
    }
    this.errorMessage = 'Please wait...';
    const mem: MemberPremiumInput = {
      age: this.member.age,
      occupationId: this.member.occupationId,
      sumInsured: this.member.sumInsured
    };
    this.memberService.calculatePremium(mem).pipe(takeUntil(this.ngUnsubscribe)).subscribe({
      next: result => {
        this.premium = result;
        this.errorMessage = '';
      },
      error: error => {
        console.error(error);
        this.errorMessage = error?.message || 'Sorry, something went wrong!';
      }
    });
  }
  padZeroes(val: number): string {
    if (val > 9) { return val + ''; }
    else { return '0' + val; }
  }
  //roundToTwoDecimals(val:number) {

  //}
  public ngOnDestroy(): void {
    this.ngUnsubscribe.next(true);
    this.ngUnsubscribe.complete();
  }
}
