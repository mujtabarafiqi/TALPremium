import { Component, OnInit, ViewChild } from '@angular/core';
import { Member } from '../models/member';
import { NgForm } from '@angular/forms';
import { Occupation } from '../models/occupation';
import { OccupationServiceService } from '../services/occupation-service.service';

@Component({
  selector: 'app-member',
  templateUrl: './member.component.html',
  styleUrls: ['./member.component.css']
})
export class MemberComponent implements OnInit {
  @ViewChild('memberForm') public addCompanyForm!: NgForm;
  member: Member = {
    age: 0,
    dateOfBirth: new Date(),
    name: '',
    occupationId: undefined,
    sumInsured: 0
  }
  occupations: Occupation[] = [];
  constructor(private occupationService: OccupationServiceService) {

  }

  ngOnInit(): void {
    this.occupationService.getAllOccupations().subscribe(result => {
      this.occupations = result;
    }, error => console.error(error));
  }

}
