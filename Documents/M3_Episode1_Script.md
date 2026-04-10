# M3 ANIMATED SERIES -- EPISODE 1 SCRIPT

[EPISODE]
Number: 1
Title: The Vertex & The Funeral
Runtime: 10-12 min
Scenes: 3

[CHARACTERS]
| Name    | Description                            | Outfit       | Voice       |
|---------|----------------------------------------|--------------|-------------|
| Pandora | Frustrated scientist, lab coat         | lab_coat     | female_01   |
| Dad     | Pandora's father (voice only, intercom)| none         | male_01     |
| Iris    | AI assistant (voice only, ambient)     | none         | female_03   |
| Luci    | Imposing, beautiful but terrifying     | dark_formal  | male_02     |
| Eve     | Luci's companion, curious and timid    | simple_dress | female_02   |
| Siple   | Small thin blue Faelend creature       | faelend_blue | creature_01 |

[PROPS]
| Prop ID          | Description                     | Used In   | Interaction            |
|------------------|---------------------------------|-----------|------------------------|
| prop_mirror      | Wall or standing mirror         | Scene 1   | Pandora checks teeth   |
| prop_apple       | A fresh apple                   | Scene 1   | Luci holds, Eve bites  |
| prop_souvenir    | Unknown object held by Siple    | Scene 1   | Luci takes from Siple  |

[SETS]
| Scene | Set                              | Set ID | Reuse     |
|-------|----------------------------------|--------|-----------|
| 1     | The Vertex Lab                   | SET_A  | Recurring |
| 2     | Traditional Church Interior      | SET_B  | One-off   |
| 3     | Church Front Steps & Parking Lot | SET_C  | One-off   |

[VOICE LINE PATTERN]
ep1_sc{S}_{character}_{NNN}.wav

---

=== SCENE 1 ===
INT. THE VERTEX LAB - UNKNOWN TIME
SET: The Vertex Lab (SET_A)
CAST: Pandora (frustrated), Siple (skittish), Luci (smug), Eve (curious)

[BEAT 1 | 0:00] Cold open -- Pandora's experiment has failed, calls Dad for help

[SHOT 1 | Wide, Static | Subject: Pandora | Duration: 6s]
Establishing shot. Frosted glass walls glow with ambient light. Pandora stands alone at the central experiment station.

[AMB: vertex_lab_hum | Loop | Volume: low]
[MUS: lab_ambient_tension | Fade: in 3s]

[ANIM: Pandora | react_frustrated | slams hands on table]

PANDORA                                              [VO: ep1_sc1_pandora_001]
[LOOK: experiment station]
I don't understand, Dad, how this is possible. After so many successful recreations, how could it just stop working?

[SHOT 2 | Mid, Static | Subject: Pandora | Duration: 4s]

DAD                                                  [VO: ep1_sc1_dad_001]
Did you turn it off and turn it back on again?

PANDORA                                              [VO: ep1_sc1_pandora_002]
[LOOK: ceiling] [ANIM: react_frustrated | sighs heavily]
Yes. Three times now.

[SHOT 3 | Mid, Tracking | Subject: Pandora | Duration: 6s]
Pandora pushes away from the table and paces.

[ANIM: Pandora | locomotion_pace | pacing along frosted glass walls]

DAD                                                  [VO: ep1_sc1_dad_002]
Maybe you should try again.

PANDORA                                              [VO: ep1_sc1_pandora_003]
[LOOK: ceiling] [ANIM: react_frustrated | throws arms up]
You have to be kidding me. Is that the extent of your troubleshooting? If it did not fix anything the first three times, how is turning it off and turning it back on a fourth time going to help? How are you even in charge of tech support?

[SHOT 4 | Mid, Static | Subject: Pandora | Duration: 3s]

DAD                                                  [VO: ep1_sc1_dad_003]
I can send my assistants--

PANDORA                                              [VO: ep1_sc1_pandora_004]
[GESTURE: gesture_headshake]
Oh no, I don't want your gold diggers' drama here.

DAD                                                  [VO: ep1_sc1_dad_004]
They are not gold diggers, they are golden--

[SHOT 5 | Close-up, Static | Subject: Pandora | Duration: 3s]

PANDORA                                              [VO: ep1_sc1_pandora_005]
[LOOK: ceiling]
Girls? Women? Rust buckets? I don't care what you call them, I don't want them here.

[SHOT 6 | Mid, Static | Subject: Pandora | Duration: 5s]
Pandora's expression shifts -- she knows she went too far.

DAD                                                  [VO: ep1_sc1_dad_005]
Dora. That was really insensitive. You should watch that mouth of yours. If you think something bad is going to come out of it...don't open it.

[ANIM: Pandora | react_defeated | buries face in hands]

PANDORA                                              [VO: ep1_sc1_pandora_006]
[LOOK: floor]
I know. I know, I'm sorry, Dad. I am just...I'm really frustrated.

DAD                                                  [VO: ep1_sc1_dad_006]
Apology accepted, but you could make it up to me.

[BEAT 2 | 0:50] Dad's matchmaking attempt -- comedy beat

[SHOT 7 | Mid, Static | Subject: Pandora | Duration: 4s]

PANDORA                                              [VO: ep1_sc1_pandora_007]
[ANIM: idle_sigh | hands still covering face]
How...how can I make it up to you?

DAD                                                  [VO: ep1_sc1_dad_007]
Promise not to get mad--

[SHOT 8 | Close-up, Static | Subject: Pandora | Duration: 3s]

PANDORA                                              [VO: ep1_sc1_pandora_008]
[LOOK: ceiling] [ANIM: react_frustrated | lowers hands from face]
I am already mad and you are making it worse. Just...how.

[MUS: lab_comedy_light | Fade: in 2s]

DAD                                                  [VO: ep1_sc1_dad_008]
I overheard a certain someone tell his brothers he has his eye on you. I would bet my ass that if I set you two up--

[SHOT 9 | Mid, Static | Subject: Pandora | Duration: 5s]

PANDORA                                              [VO: ep1_sc1_pandora_009]
[GESTURE: gesture_point | pointing aggressively at nothing]
No Dad...just no. One, your 'Bro' is not my type at all. And, two, if I hear him say 'hey baby, let me show you the thunder' one more time...I'm going to--

DAD                                                  [VO: ep1_sc1_dad_009]
Open a can of whoopass?

[SHOT 10 | Close-up, Static | Subject: Pandora | Duration: 4s]

PANDORA                                              [VO: ep1_sc1_pandora_010]
[LOOK: ceiling]
No, I am not opening anything, I was going to say report him for sexual harassment.

DAD                                                  [VO: ep1_sc1_dad_010]
Fine. Have it your way. Then if you won't let me set you up, how about you accept a gift I made?

PANDORA                                              [VO: ep1_sc1_pandora_011]
[ANIM: idle_crossed_arms | folds arms]
The 'gifts' you make are never really gifts. Just really bad jokes.

[BEAT 3 | 1:30] Dad's terrible joke -- tension relief

[SHOT 11 | Mid, Static | Subject: Pandora | Duration: 4s]

DAD                                                  [VO: ep1_sc1_dad_011]
I make them up and I gift them to you. Where is the gratitude? Come on, aren't you curious?

PANDORA                                              [VO: ep1_sc1_pandora_012]
[LOOK: ceiling]
Nope, just nauseous. But fine. Let me hear your latest 'gift' before I change my mind.

[SHOT 12 | Close-up, Static | Subject: Pandora | Duration: 3s]

DAD                                                  [VO: ep1_sc1_dad_012]
[SFX: dad_squeak | Source: intercom | Global]
Really?

[ANIM: Pandora | react_relieved | trying not to smile, corners of mouth curl]

PANDORA                                              [VO: ep1_sc1_pandora_013]
Yes, really.

[SHOT 13 | Mid, Static | Subject: Pandora | Duration: 6s]

DAD                                                  [VO: ep1_sc1_dad_013]
Ok...ok...ok, what do you get if you put Tea in a Forge?

PANDORA                                              [VO: ep1_sc1_pandora_014]
[ANIM: idle_sigh | sighing, bracing for impact]
I suspect a headache. This is going to be bad, isn't it? I don't know, what do you get?

DAD                                                  [VO: ep1_sc1_dad_014]
I ForgeT.
[SFX: dad_laughter | Source: intercom | Global]

[SHOT 14 | Close-up, Static | Subject: Pandora | Duration: 4s]
[ANIM: Pandora | react_defeated | shakes head, face in hands]

DAD                                                  [VO: ep1_sc1_dad_015]
Oh, that one was funny, and you know it.

[SHOT 15 | Mid, Static | Subject: Pandora | Duration: 6s]

PANDORA                                              [VO: ep1_sc1_pandora_015]
[LOOK: experiment station]
Unfortunately, I have heard worse...from you. So, are you going to come here in person so you can 'turn it off and turn it back on again' yourself or what?

DAD                                                  [VO: ep1_sc1_dad_016]
I have a few irons in the fire right now but will be over later. Ha, 'irons in the fire', see what I did there?

PANDORA                                              [VO: ep1_sc1_pandora_016]
[ANIM: react_relieved | half smile]
You are so lame....and Dad stop betting your 'ass' because someday you might lose that bet and then you'll be limping everywhere you go. Ha, 'lame...ass...limping', see what I did there?

DAD                                                  [VO: ep1_sc1_dad_017]
Thanks for the disability shaming. Love ya, Dora.

[SHOT 16 | Mid, Static | Subject: Pandora | Duration: 3s]

PANDORA                                              [VO: ep1_sc1_pandora_017]
[LOOK: floor] [ANIM: react_relieved | soft smile]
Love you too, Dad.

[BEAT 4 | 2:15] Iris announces Luci -- tone shifts to tension

[MUS: lab_comedy_light | Fade: out 2s]
[MUS: luci_tension_build | Fade: in 3s]

[ANIM: Pandora | react_defeated | head drops to hands on table]

IRIS                                                 [VO: ep1_sc1_iris_001]
Your favorite person is here to see you. Should I let him in?

[SHOT 17 | Close-up, Static | Subject: Pandora | Duration: 4s]
[ANIM: Pandora | react_frustrated | grinds teeth, lifts head, balls fists]

PANDORA                                              [VO: ep1_sc1_pandora_018]
[LOOK: ceiling]
I don't have time for him, Iris. What does he want?

IRIS                                                 [VO: ep1_sc1_iris_002]
I don't know, but he has a visitor with him.

[BEAT 5 | 2:30] Pandora's vanity moment -- she cares how she looks for Luci

[SHOT 18 | Mid, Tracking | Subject: Pandora | Duration: 6s]
Pandora bolts from the table to the mirror.

[ANIM: Pandora | locomotion_run | rushes to the mirror]
[PROP: Pandora | prop_mirror | interacting with mirror]
[ANIM: Pandora | custom_check_appearance | pulls back lips to check teeth, smoothes lab coat]

[SHOT 19 | Close-up, Static | Subject: Pandora in mirror | Duration: 4s]
Pandora tries different poses -- hand on hip, arms crossed, one hand on table. Settles on composed.

[ANIM: Pandora | idle_pose | cycling through poses, settling on composed]

PANDORA                                              [VO: ep1_sc1_pandora_019]
[ANIM: react_relieved | takes deep breath, puts on a smile]
Okay, let them in.

[BEAT 6 | 2:50] Luci and Eve arrive -- power entrance

[SFX: door_swoosh | Source: entryway | Spatial]

[SHOT 20 | Wide, Low Angle | Subject: Luci, Eve | Duration: 5s]
The high-tech entryway slides open. Luci strides in confidently. Eve follows timidly behind.

[ANIM: Luci | locomotion_walk | confident, smug stride]
[ANIM: Eve | locomotion_walk | follows timidly, half-step behind]

[SHOT 21 | Mid, Static | Subject: Pandora | Duration: 4s]
Pandora's smile curdles. She was expecting someone else.

[ANIM: Pandora | react_surprised | sneer at Luci, catches sight of Eve, smile drops to scowl]
[ANIM: Pandora | idle_crossed_arms | arms crossed tightly]

PANDORA                                              [VO: ep1_sc1_pandora_020]
[LOOK: Luci]
What do you want, Luci?

[SHOT 22 | Over-shoulder Pandora, Mid | Subject: Luci | Duration: 3s]

LUCI                                                 [VO: ep1_sc1_luci_001]
[LOOK: Pandora]
Nice to see you too, and you know that is not my name.

[SHOT 23 | Close-up, Static | Subject: Pandora | Duration: 2s]

PANDORA                                              [VO: ep1_sc1_pandora_021]
[LOOK: Luci]
I'm busy.

[SHOT 24 | Mid, Static | Subject: Luci | Duration: 5s]

LUCI                                                 [VO: ep1_sc1_luci_002]
[LOOK: Pandora] [ANIM: react_smug | sideways smirk]
Oh, I know. Savior of the people and all, it must be a painful crown of thorns to bear. Despite it being a complete accident.

[SHOT 25 | Mid Two-Shot | Subject: Pandora, Luci | Duration: 4s]

PANDORA                                              [VO: ep1_sc1_pandora_022]
[LOOK: Eve] [GESTURE: gesture_point | points at Eve]
Who is this?

LUCI                                                 [VO: ep1_sc1_luci_003]
[LOOK: Eve]
Oh, this is my new assistant, Eve.

[SHOT 26 | Mid, Static | Subject: Eve | Duration: 3s]
[ANIM: Eve | gesture_wave | small wave from behind Luci]

PANDORA                                              [VO: ep1_sc1_pandora_023]
[LOOK: Eve] [ANIM: idle_sigh | sighs]
Nice to me--

[SHOT 27 | Mid Two-Shot | Subject: Luci, Eve | Duration: 5s]
[ANIM: Luci | locomotion_step | steps in front of Eve, blocking Pandora's view]
[ANIM: Luci | idle_crossed_arms | crosses arms]

LUCI                                                 [VO: ep1_sc1_luci_004]
[LOOK: Pandora]
Don't speak to her. You are not going to taint another of my assistants. And, you don't need air, so why do you insist on mimicking those lesser creatures?

[SHOT 28 | Mid, Static | Subject: Pandora | Duration: 5s]

PANDORA                                              [VO: ep1_sc1_pandora_024]
[LOOK: Luci] [ANIM: idle_hands_hips | hands on hips]
Now! Now, they are lesser creatures? What happened to 'they are the discovery of a lifetime'? 'Had potential to surpass our connection to the Cailika'?

[BEAT 7 | 3:20] The flood reveal -- Luci's cruelty

[MUS: luci_tension_build | Fade: out 1s]
[MUS: flood_reveal_dark | Fade: in 2s]

[SHOT 29 | Close-up, Static | Subject: Luci | Duration: 4s]

LUCI                                                 [VO: ep1_sc1_luci_005]
[LOOK: Pandora] [ANIM: react_angry | snarls]
You know what happened, but it doesn't matter. They won't be a problem much longer.

[SHOT 30 | Mid, Tracking | Subject: Pandora | Duration: 4s]

PANDORA                                              [VO: ep1_sc1_pandora_025]
[LOOK: Luci] [ANIM: locomotion_step | steps toward Luci, narrows eyes]
Why? What did you do?

[SHOT 31 | Close-up, Static | Subject: Luci | Duration: 5s]

LUCI                                                 [VO: ep1_sc1_luci_006]
[LOOK: Pandora] [ANIM: react_smug | toothy grin]
I increased the rainfall. All those foul experiments will drown. Technically, all of them will drown.

[SHOT 32 | Mid Two-Shot | Subject: Pandora, Luci | Duration: 6s]

PANDORA                                              [VO: ep1_sc1_pandora_026]
[ANIM: locomotion_turn | turns back on Luci]
Again, why? I had it under control. They were no longer a threat.
[ANIM: interact_poke | spins around, pokes Luci in chest]
[LOOK: Luci]
You truly are a sadist. They will all die because of your hubris.

LUCI                                                 [VO: ep1_sc1_luci_007]
[LOOK: Pandora] [ANIM: react_smug | unfazed]
Funny. That is just what Lili said before I dismissed her from the Vertex.

[SHOT 33 | Close-up, Static | Subject: Pandora | Duration: 3s]

PANDORA                                              [VO: ep1_sc1_pandora_027]
[LOOK: Luci] [GESTURE: gesture_lower_hand | lowers finger, whispers]
You had no right.

[SHOT 34 | Close-up, Dolly In | Subject: Luci | Duration: 6s]

LUCI                                                 [VO: ep1_sc1_luci_008]
[LOOK: Pandora] [ANIM: locomotion_lean | leans in close to Pandora]
I had every right. Lili was my assistant, she wasn't performing satisfactorily, and I dismissed her. Hence, my new assistant Eve. Maybe if you didn't use those nasty Faelends as your assistants, you could have had Lili for yourself...oh, wait, I guess you did have her for yourself.
[ANIM: react_smug | flashes teeth]
What too soon?

[BEAT 8 | 3:55] Pandora breaks -- emotional low point

[SHOT 35 | Mid, Static | Subject: Pandora | Duration: 4s]
[ANIM: Pandora | react_defeated | falls to knees, covers face]

PANDORA                                              [VO: ep1_sc1_pandora_028]
Get out.

LUCI                                                 [VO: ep1_sc1_luci_009]
[LOOK: Pandora]
Poor Doctor Pandora. You just can't seem to keep a lid on--

[BEAT 9 | 4:05] Siple chaos -- creature bursts in

[SFX: creature_screech | Source: Siple | Spatial]

[SHOT 36 | Wide, Static | Subject: full lab | Duration: 4s]
Siple bursts into frame, running past Eve.

[ANIM: Siple | locomotion_run | runs past Eve toward Luci]
[ANIM: Eve | react_scared | jumps back, hides behind Luci]

EVE                                                  [VO: ep1_sc1_eve_001]
[LOOK: Siple]
Is that a Faelend?

[SHOT 37 | Mid, Static | Subject: Luci, Siple | Duration: 4s]
[ANIM: Luci | interact_grab_throat | grabs Siple by throat, holds at arm's length]

LUCI                                                 [VO: ep1_sc1_luci_010]
[LOOK: Siple]
Yes, and this one is especially foolish.

[SHOT 38 | Mid Two-Shot | Subject: Pandora, Luci | Duration: 3s]

PANDORA                                              [VO: ep1_sc1_pandora_029]
[LOOK: Siple] [ANIM: locomotion_jump_up | jumps to feet]
Let Siple go.

[SHOT 39 | Mid, Static | Subject: Luci | Duration: 5s]
[ANIM: Luci | interact_move_away | moves Siple out of Pandora's reach]
[PROP: Siple | prop_souvenir | holding an unknown object]
[ANIM: Luci | interact_take_object | takes object from Siple's grip]

LUCI                                                 [VO: ep1_sc1_luci_011]
[LOOK: prop_souvenir, then Pandora]
What's this? Now you have them collecting souvenirs? I could have you cast out of the Vertex for this.

[SHOT 40 | Mid, Static | Subject: Pandora | Duration: 3s]
[ANIM: Pandora | interact_grab | tries to grab Siple from Luci]

PANDORA                                              [VO: ep1_sc1_pandora_030]
[LOOK: Luci]
Let go of Siple, you slimy snake. I have approval from the Council to collect objects for experimentation.

[BEAT 10 | 4:30] The apple trap -- Luci manipulates Eve

[MUS: flood_reveal_dark | Fade: out 1s]
[MUS: apple_trap_tension | Fade: in 2s]

[SHOT 41 | Mid, Static | Subject: Luci | Duration: 4s]
[ANIM: Luci | interact_release | drops Siple]
[ANIM: Siple | locomotion_run | scurries to hide behind Pandora]

Luci holds the object up, inspects it. It's an apple.

[ANIM: Luci | interact_inspect | lifts object, inspects it, turns to Eve]
[PROP: Luci | prop_apple | holding the apple (prop_souvenir revealed as prop_apple)]

LUCI                                                 [VO: ep1_sc1_luci_012]
[LOOK: Eve]
This is one of their foods. It is called an apple. Go ahead, take a bite.

[SHOT 42 | Close-up, Static | Subject: Eve | Duration: 4s]

EVE                                                  [VO: ep1_sc1_eve_002]
[LOOK: prop_apple] [ANIM: interact_take_object | takes apple, holds at a distance]
[PROP: Eve | prop_apple | holding apple cautiously]
I don't think I should. Is it safe?

[SHOT 43 | Mid Two-Shot | Subject: Pandora, Luci | Duration: 4s]
[ANIM: Pandora | interact_grab | reaches for the apple]
[ANIM: Luci | interact_grab | grabs Pandora's wrist]
[ANIM: Luci | interact_shush | puts finger on Pandora's lips]

[SHOT 44 | Close-up, Static | Subject: Pandora | Duration: 2s]
[ANIM: Pandora | react_surprised | mouth open, no sound comes out]

[SHOT 45 | Mid, Static | Subject: Luci | Duration: 5s]

LUCI                                                 [VO: ep1_sc1_luci_013]
[LOOK: Eve]
If you don't take a bite, I will deem you an unworthy assistant. There is only so much space in the Vertex, and former assistants have no place here.

[SHOT 46 | Close-up, Static | Subject: Eve | Duration: 4s]
[ANIM: Eve | interact_bite | slowly brings apple to mouth, bites]

EVE                                                  [VO: ep1_sc1_eve_003]
[LOOK: prop_apple]
It's...It's delicious.

[SHOT 47 | Mid Two-Shot | Subject: Luci, Pandora | Duration: 3s]
[ANIM: Luci | interact_release | releases Pandora's wrist, steps back]

[SHOT 48 | Mid, Static | Subject: Pandora | Duration: 3s]

PANDORA                                              [VO: ep1_sc1_pandora_031]
[LOOK: Eve] [ANIM: react_angry | screams]
What have you done?

[SHOT 49 | Close-up, Static | Subject: Eve | Duration: 3s]
[SFX: apple_drop | Source: prop_apple | Spatial]
[ANIM: Eve | interact_drop | apple falls from hand to floor]

EVE                                                  [VO: ep1_sc1_eve_004]
[LOOK: Pandora]
I...I didn't have a choice.

[SHOT 50 | Mid Two-Shot | Subject: Pandora, Luci | Duration: 4s]

PANDORA                                              [VO: ep1_sc1_pandora_032]
[LOOK: Luci] [GESTURE: gesture_point | points at Luci]
You just got her exiled, and you know it.

[SHOT 51 | Mid, Static | Subject: Luci | Duration: 6s]

LUCI                                                 [VO: ep1_sc1_luci_014]
[LOOK: Pandora] [ANIM: react_smug | wide smile, then turns to Eve]
I am afraid she is correct. Pandora may have the authorization to bring objects here to experiment, but no one is allowed to foul their bodies with substances from other worlds. It is now my duty as a Council member to report you.

[BEAT 11 | 5:00] Eve's devastation

[MUS: apple_trap_tension | Fade: out 1s]
[MUS: eve_devastation | Fade: in 2s]

[SHOT 52 | Close-up, Static | Subject: Eve | Duration: 5s]
[ANIM: Eve | react_scared | hand to mouth, chest heaving, wide eyes]

EVE                                                  [VO: ep1_sc1_eve_005]
[LOOK: Pandora, then Luci]
But you said...you said--

[SHOT 53 | Mid, Static | Subject: Luci | Duration: 5s]

LUCI                                                 [VO: ep1_sc1_luci_015]
[LOOK: Eve]
It was a test, and you failed. It is not my fault you didn't follow the rules.
[ANIM: interact_touch_shoulder | hand on Eve's shoulder]
I would guess you have about two cycles. Go use them to say goodbye.

[SHOT 54 | Close-up, Static | Subject: Eve | Duration: 4s]

EVE                                                  [VO: ep1_sc1_eve_006]
[LOOK: Pandora] [ANIM: react_defeated | pleading look]
Is there anything you can do?

[SHOT 55 | Close-up, Static | Subject: Pandora | Duration: 3s]

PANDORA                                              [VO: ep1_sc1_pandora_033]
[LOOK: Eve] [ANIM: react_defeated | hangs head]
I'm sorry, no.

[SHOT 56 | Wide, Static | Subject: Eve exiting | Duration: 3s]
[ANIM: Eve | locomotion_run | turns and runs from the room]
[SFX: door_swoosh | Source: entryway | Spatial]

[BEAT 12 | 5:25] Luci's final blow -- the narrative reveal

[MUS: eve_devastation | Fade: out 1s]
[MUS: narrative_reveal | Fade: in 2s]

[SHOT 57 | Mid Two-Shot | Subject: Pandora, Luci | Duration: 4s]

PANDORA                                              [VO: ep1_sc1_pandora_034]
[LOOK: Luci]
You're a Council member! But how? When?

LUCI                                                 [VO: ep1_sc1_luci_016]
[LOOK: Pandora]
Just recently, in fact, which is why I am here. The Council wants to know your progress on creating more dimensions and to inform you...
[ANIM: react_smug | broad smile, points at Siple]
[LOOK: Siple]
...we pushed a new narrative with your pets, and you will be happy to know, you are the star.

[SHOT 58 | Mid, Static | Subject: Pandora, Siple | Duration: 4s]
[ANIM: Pandora | interact_touch_head | turns, hand on Siple's blue antlered head]

[SHOT 59 | Mid, Static | Subject: Luci | Duration: 3s]
[ANIM: Luci | gesture_headshake | shakes head disapprovingly]

LUCI                                                 [VO: ep1_sc1_luci_017]
[LOOK: Pandora]
There you go again, mimicking those foul human mannerisms.

[SHOT 60 | Close-up, Static | Subject: Pandora | Duration: 4s]

PANDORA                                              [VO: ep1_sc1_pandora_035]
[LOOK: Luci]
You made me out to be the reason for all their pain and suffering.

[SHOT 61 | Mid, Static | Subject: Luci at doorway | Duration: 6s]

LUCI                                                 [VO: ep1_sc1_luci_018]
[LOOK: Pandora] [ANIM: locomotion_walk | backing toward door]
Not me, the Council did. I might have suggested to your pet a few suggestions, but they had to approve it. It won't matter now, though. All the humans will all drown soon. I expect your report on the dimensional replication progress by the end of the cycle.

[ANIM: Luci | locomotion_walk | turns and exits]
[SFX: door_swoosh | Source: entryway | Spatial]

[BEAT 13 | 5:55] Aftermath -- Pandora's plan (hope)

[MUS: narrative_reveal | Fade: out 2s]
[MUS: pandora_resolve | Fade: in 3s]

[SHOT 62 | Mid Two-Shot, Static | Subject: Pandora, Siple | Duration: 5s]
Pandora stares at the empty doorway. Siple presses against her leg.

[ANIM: Pandora | idle_pose | staring at empty doorway]

PANDORA                                              [VO: ep1_sc1_pandora_036]
[LOOK: entryway]
Iris, did you hear all that?

IRIS                                                 [VO: ep1_sc1_iris_003]
Every single word, and I may have recorded it all too.

[SHOT 63 | Mid, Static | Subject: Pandora | Duration: 4s]

PANDORA                                              [VO: ep1_sc1_pandora_037]
[LOOK: ceiling]
Good, send a copy to the Council. He might have tricked Eve, but he will be removed from the Vertex as well for doing so.

IRIS                                                 [VO: ep1_sc1_iris_004]
What are you going to do about the humans?

[SHOT 64 | Mid Two-Shot, Static | Subject: Pandora, Siple | Duration: 5s]
[ANIM: Pandora | locomotion_turn | turns, looks down at Siple]

PANDORA                                              [VO: ep1_sc1_pandora_038]
[LOOK: Siple]
The Faelends are going to warn as many as they can that a flood is coming. Maybe the people will have enough time to build arks or get to higher ground.

IRIS                                                 [VO: ep1_sc1_iris_005]
What about the narrative?

[SHOT 65 | Close-up, Static | Subject: Pandora | Duration: 4s]

PANDORA                                              [VO: ep1_sc1_pandora_039]
[LOOK: Siple] [ANIM: react_relieved | a real smile, first genuine one in the scene]
I have an idea for a new narrative.

[MUS: pandora_resolve | Fade: out 3s]

[TRANSITION: Fade to Black | Duration: 2s]

---

=== SCENE 1 ASSET MANIFEST ===

**Voice Lines: 82 total**
- Pandora: 39 lines (ep1_sc1_pandora_001 through _039)
- Dad: 17 lines (ep1_sc1_dad_001 through _017)
- Luci: 18 lines (ep1_sc1_luci_001 through _018)
- Eve: 6 lines (ep1_sc1_eve_001 through _006)
- Iris: 5 lines (ep1_sc1_iris_001 through _005)
- Siple: 0 lines (creature vocalizations via SFX only)

**Shots: 65**

**Animation Intents (unique): 32**
| Intent | Category | Clip Likelihood | Notes |
|--------|----------|----------------|-------|
| react_frustrated | React | HIGH | Mixamo/generic |
| locomotion_pace | Locomotion | HIGH | Basic walk variant |
| react_defeated | React | HIGH | Mixamo/generic |
| idle_sigh | Idle | HIGH | Subtle breathing anim |
| gesture_headshake | Gesture | HIGH | Common gesture |
| gesture_point | Gesture | HIGH | Common gesture |
| react_relieved | React | MEDIUM | Smile/relax transition |
| idle_crossed_arms | Idle | HIGH | Common idle |
| idle_hands_hips | Idle | HIGH | Common idle |
| idle_pose | Idle | HIGH | Standing neutral |
| locomotion_run | Locomotion | HIGH | Basic run |
| locomotion_walk | Locomotion | HIGH | Basic walk |
| locomotion_step | Locomotion | MEDIUM | Single step forward |
| locomotion_turn | Locomotion | MEDIUM | Turn in place |
| locomotion_jump_up | Locomotion | MEDIUM | Jump to standing |
| locomotion_lean | Locomotion | LOW | Lean forward menacingly |
| react_smug | React | MEDIUM | Smirk/grin expression |
| react_angry | React | HIGH | Mixamo/generic |
| react_surprised | React | HIGH | Mixamo/generic |
| react_scared | React | HIGH | Mixamo/generic |
| gesture_wave | Gesture | HIGH | Common gesture |
| gesture_lower_hand | Gesture | MEDIUM | Lowering pointed hand |
| interact_grab_throat | Interact | LOW | Custom -- grab by neck |
| interact_take_object | Interact | MEDIUM | Take object from hand |
| interact_release | Interact | MEDIUM | Release grip |
| interact_move_away | Interact | LOW | Move held object away |
| interact_inspect | Interact | MEDIUM | Hold up and look at object |
| interact_grab | Interact | MEDIUM | Reach/grab motion |
| interact_shush | Interact | LOW | Finger to lips |
| interact_bite | Interact | LOW | Bring object to mouth |
| interact_drop | Interact | MEDIUM | Release object, let fall |
| interact_touch_head | Interact | LOW | Hand on creature's head |
| interact_touch_shoulder | Interact | MEDIUM | Hand on shoulder |
| interact_poke | Interact | LOW | Poke in chest |
| custom_check_appearance | Custom | NONE | Mirror check -- UMotion |

**SFX: 6 unique**
- door_swoosh (x3 uses)
- dad_squeak
- dad_laughter
- creature_screech
- apple_drop

**Ambience: 1**
- vertex_lab_hum

**Music Cues: 7**
- lab_ambient_tension (scene open)
- lab_comedy_light (dad jokes section)
- luci_tension_build (Luci arrival)
- flood_reveal_dark (flood reveal)
- apple_trap_tension (Eve and apple)
- eve_devastation (Eve's exile)
- narrative_reveal (Luci's final blow)
- pandora_resolve (Pandora's plan, scene close)

**Props: 3**
- prop_mirror (wall mirror, Pandora interaction)
- prop_apple (apple -- revealed from prop_souvenir)
- prop_souvenir (unknown object held by Siple, becomes prop_apple)
