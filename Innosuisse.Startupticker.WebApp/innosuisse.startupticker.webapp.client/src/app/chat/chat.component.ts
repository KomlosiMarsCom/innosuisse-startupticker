import { Component } from '@angular/core';
import { ChatBotService } from '../../../typescript-client';
import { Message, MessageEnteredEvent, User } from 'devextreme/ui/chat';

@Component({
  selector: 'app-chat-bot',
  templateUrl: './chat.component.html',
  styleUrl: './chat.component.css'
})
export class ChatBotComponent {
  currentUser: User;
  supportAgent: User;
  currentSessionId: string;
  messages: Message[];
  userChatTypingUsers: User[];

  constructor(private readonly _chatBotService: ChatBotService) {
    this.currentUser = {
      id: this.generateGUID(),
      name: "Anonymous user"
    };

    this.supportAgent = {
      id: this.generateGUID(),
      name: "AI support assistent"
    };

    let initMessages: Message[] = [];
    let inituserChatTypingUsers: User[] = []
    this.messages = initMessages;
    this.userChatTypingUsers = inituserChatTypingUsers;

    this.currentSessionId = this.generateGUID();
  }

  ngOnInit() { }

  onMessageEntered(event: MessageEnteredEvent) {
    this.messages.push(event.message);
    debugger;
    this._chatBotService.askPost({
      sessionId: this.currentSessionId,
      userMessage: event.message.text
    })
    .subscribe(response => {
      this.messages.push({
        id: this.generateGUID(),
        author: this.supportAgent,
        text: response,
        timestamp: Date()
      })
    });
  }

  userChatOnTypingStart() {
    ///debugger;
    //this.appService.userChatOnTypingStart();
  }

  userChatOnTypingEnd() {
    ///debugger;
    //this.appService.userChatOnTypingEnd();
  }

  supportChatOnTypingStart() {
    //debugger;
    //this.appService.supportChatOnTypingStart();
  }

  supportChatOnTypingEnd() {
    //debugger;
    //this.appService.supportChatOnTypingEnd();
  }

  generateGUID(): string {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
      const r = (Math.random() * 16) | 0;
      const v = c === 'x' ? r : (r & 0x3) | 0x8;
      return v.toString(16);
    });
  }
}
