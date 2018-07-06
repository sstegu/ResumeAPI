import { Component, Inject } from '@angular/core';
import { ApiService } from '../../api';
import { Globals } from '../../globals';
import { ChangeDetectorRef } from '@angular/core';

@Component({
    selector: 'home',
    styleUrls: ['../../css/common.css', './home.component.css'],
    templateUrl: './home.component.html',
    providers: [ApiService]
})
export class HomeComponent {
    private cvData: JSON;
    private error: boolean = false;
    private wait: boolean = false;
    private company: string = "";
    private firstName: string = "";
    private lastName: string = "";

    constructor(private api: ApiService, private globals: Globals) {
        this.wait = false;
        this.company = "";
        if (this.globals.companyGuid != null && this.globals.companyGuid.trim().length > 0) {
            this.company = this.globals.companyGuid;
            this.firstName = this.globals.firstName;
            this.lastName = this.globals.lastName;

            this.getCoverData();
        }


    }

    private getCoverData(): void {
        this.error = false;
        this.wait = true;

        this.api.GetCoverData(this.company).subscribe(result => {
            if (result.ok) {
                this.cvData = result.json();
                //save global
                this.globals.companyGuid = this.company;
                this.globals.firstName = this.firstName;
                this.globals.lastName = this.lastName;

            }
        }, error => {
            this.error = true;
            this.wait = false;
        },
            () => {
                this.wait = false;
            });


    }

}


