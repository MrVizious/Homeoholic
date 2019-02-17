# To Do List
This document aims to be a list of thing that are missing or that have to be done. They will (hopefully) be categorized for easier reference. Also, there will be four different sections: Level Design, Code, Bugs and Ideas / Backlog.

## Level Design
Here there will be listed all the things that have to be done not necessarily in-code, and also helps keeping track of which room specific stuff has to be done.
- [ ] Name of the Boy
- [ ] Entrance
  - [ ] Map
  - [ ] Items
    - [ ] Door
      - [x] Sprite
      - [ ] Action
    - [ ] Umbrella Holder
      - [x] Sprite
      - [ ] Action
    - [ ] Table
      - [x] Sprite
      - [ ] Action
    - [ ] Painting
      - [x] Sprite
      - [ ] Action
- [ ] Kitchen / Living room
  - [ ] Dog
    - [ ] Sprite
    - [ ] Action
    - [ ] Win routine
    - [ ] Lose routine
  - [ ] Sofa
    - [ ] Sprite
    - [ ] Action Post-completion
  - [ ] Granpa
    - [ ] Sprite
    - [ ] Action
    - [ ] Win routine
    - [ ] Lose routine
    - [ ] Animation
  - [ ] Sink
    - [ ] Sprite
    - [ ] Action
    - [ ] Animation
- [ ] Garage
- [ ] 2<sup>nd</sup> floor corridor
- [ ] Bathroom
- [ ] Parents' room (with wardrobe)
- [ ] Your room
- [ ] Garden

## Code
Ok, so you don't know what to code? Look in here, it should help you find something cool to do ;)
- [x] Pause Menu
- [ ] Start Menu
- [ ] Reload room if not completed
- [ ] Letters UI
  - [x] LetterHolders appear automatically with correct size
  - [x] Letters appear when pressed
  - [x] Letters disappear when erased
  - [x] Letters are highlighted while performing
  - [x] Letters disappear or turn dark when performed
  - [ ] Icon appears to ask the user to press Enter / Return
  - [ ] ¿¿ Create drag and drop system for fonts instead of loading them from Resources ??
- [x] Stall character action
- [x] No action performed visual feedback (Show a "?" on the head)
- [ ] NPC prefab
- [ ] Inventory-like UI
  - [ ] Appear when collecting item
- [x] **Pass all references to Scripts through LevelController** (Create all of the references in LevelController and make public methods to get the reference)

## Bugs
~~None right now... It will be full soon, though.~~  
Okay, here are these little bastards... Let's get rid of them:
- [x] ~~Once you pause the game, you can still input keys for the character to move~~
- [x] ~~The player doesn-t move if it has a collider activated. The Move Collider finds it and ignores the LayerMask~~
- [x] ~~The resume button doesn't work in the pause menu~~

## Ideas / Backlog
Everybody can dream... Right? Here are some ideas that could or could not be implemented, but it sure is cool to have some kind of list to write down those ideas you have at 3 AM.
- [ ] Secret room with credits (Konami Code?)
- [ ] HELP input sequence action
- [ ] AUTOMODE input sequence action
- [ ] Intro scene (Boy getting out of a taxi and moving drunkenly through the garden)
- [ ] Actions that will fail no matter what (3<sup>rd</sup> action will always, for example)
- [ ] Different levels of difficulty is based on how drunk you are (0.2, 0.5, 0.8...)