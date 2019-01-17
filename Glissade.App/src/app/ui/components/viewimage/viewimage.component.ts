import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DomSanitizer } from '@angular/platform-browser';
import { ScreenDTO } from 'src/app/models/screen-dto.model';

@Component({
  selector: 'app-viewimage',
  templateUrl: './viewimage.component.html',
  styleUrls: ['./viewimage.component.scss']
})
export class ViewimageComponent implements OnInit {

  constructor(private route: ActivatedRoute, private http: HttpClient, private _sanitizer: DomSanitizer) { }
  linkId: string;
  image = '';
  url: string = 'https://api.glissade/api/us/viewimage/';

  ngOnInit() {
    this.linkId = this.route.snapshot.paramMap.get("id")
  }
  ngAfterViewInit() {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');

    let request = this.http.get<ScreenDTO>(this.url + '?id=' + this.linkId, { headers: headers });
    request.subscribe((responseData) => {
      this.image = 'data:image/png;base64, ' + responseData.content;
    });
  }
}
