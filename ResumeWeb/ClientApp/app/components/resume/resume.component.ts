import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'home',
    templateUrl: './resume.component.html',
    styleUrls: ['./resume.component.css']
})
export class ResumeComponent {
    public candidate: JSON;

    constructor(http: Http) {

        http.get("http://localhost:55379/api/Candidates/1").subscribe(result => {
            if (result.ok) {
                this.candidate = result.json();
                console.debug(this.candidate);
            }
        }, error => console.error(error));

    }
}

