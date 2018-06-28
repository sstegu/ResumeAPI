import { Component, Inject, Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class ApiService {
    private http: Http;

    constructor(http: Http, @Inject("API_URL") private url: string, @Inject('COMPANY') private cguid: string) {
        this.http = http;
    }

    public GetResumeData(id: string): Observable<Response> {
        return this.GetData("/api/Candidates/" + id);
    }

    public GetCoverData(): Observable<Response> {
        let guid: string = this.cguid != null ? this.cguid : 'default';
        return this.GetData("/api/CVContents/" + guid);
    }

    private GetData(path: string): Observable<Response> {
        return this.http.get(this.url + path);
    }
}